using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Bullet hit: " + other.gameObject.name + ", Tag: " + other.gameObject.tag);
        if (other.CompareTag("Enemy"))
        {
            EnemyBehavior enemy = other.GetComponent<EnemyBehavior>();
            if (enemy != null)
            {
                EnemyHealthTracker healthTracker = FindObjectOfType<EnemyHealthTracker>();
                if (healthTracker != null)
                {
                    Debug.Log("Reducing global health by 1 due to bullet hit");
                    healthTracker.ReduceHealth(1f);
                }
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
    }
}