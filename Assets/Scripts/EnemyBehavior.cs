using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private GameManager gameManager;
    private float minX = -7f;
    private float maxX = 7f;
    private float spawnY = 6f;
    private bool isRespawning = false;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Debug.Log("EnemyBehavior Start - GameManager found: " + (gameManager != null));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameManager == null || gameManager.gameEnded) return; // ✅ stop logic after game end

        if (collision.gameObject.CompareTag("Player") && !isRespawning)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
                Debug.Log("Enemy collided with player, health reduced");
            }
        }
        else if (collision.gameObject.CompareTag("Ground") && !isRespawning)
        {
            EnemyHealthTracker healthTracker = FindObjectOfType<EnemyHealthTracker>();
            if (healthTracker != null)
            {
                Debug.Log("Enemy hit ground, attempting to reduce health by 1");
                healthTracker.ReduceHealth(1f);
                Debug.Log("Health reduction requested, current global health: " + gameManager.CurrentGlobalHealth);
            }
            else
            {
                Debug.LogError("EnemyHealthTracker not found!");
            }
            StartRespawn();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameManager == null || gameManager.gameEnded) return; // ✅ stop logic after game end

        if (other.CompareTag("Bullet"))
        {
            EnemyHealthTracker healthTracker = FindObjectOfType<EnemyHealthTracker>();
            if (healthTracker != null)
            {
                healthTracker.ReduceHealth(1f);
            }
            Destroy(other.gameObject);
            StartRespawn();
        }
    }

    void StartRespawn()
    {
        if (gameManager == null || gameManager.gameEnded) return; // ✅ no respawn if game ended

        isRespawning = true;
        Invoke("Respawn", 0.5f);
    }

    void Respawn()
    {
        if (gameManager == null || gameManager.gameEnded) return; // ✅ no respawn if game ended

        float randomX = Random.Range(minX, maxX);
        transform.position = new Vector3(randomX, spawnY, 0);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
        isRespawning = false;
    }
}
