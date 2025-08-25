using UnityEngine;

public class EnemyBulletBehavior : MonoBehaviour
{
    // public float speed = 3f; // Slower speed for enemy bullets
    // private Transform player;

    // void Start()
    // {
    //     player = GameObject.FindWithTag("Player")?.transform;
    //     if (player == null)
    //     {
    //         Debug.LogError("Player not found with tag 'Player'!");
    //     }
    //     Destroy(gameObject, 3f); // Destroy after 3 seconds
    // }

    // void Update()
    // {
    //     if (player != null)
    //     {
    //         Vector2 direction = (player.position - transform.position).normalized;
    //         transform.Translate(direction * speed * Time.deltaTime);
    //     }
    // }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     Debug.Log("Enemy bullet hit: " + other.gameObject.name + ", Tag: " + other.gameObject.tag);
    //     if (other.CompareTag("Player"))
    //     {
    //         PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
    //         if (playerHealth != null)
    //         {
    //             //playerHealth.TakeDamage(1);
    //         }
    //         Destroy(gameObject);
    //     }
    //     else if (other.CompareTag("Ground"))
    //     {
    //         Destroy(gameObject);
    //     }
    // }
}