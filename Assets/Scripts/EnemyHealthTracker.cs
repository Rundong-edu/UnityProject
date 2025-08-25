using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthTracker : MonoBehaviour
{
    public Slider healthBar; // Remove this if using Image-based bar
    public Image fillImage; // Add this if using the custom Image bar
    private float totalHealth = 20f;
    private int enemyCount = 1;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.globalMaxHealth = (int)totalHealth; // Sync initial max health
        }
        else
        {
            Debug.LogError("GameManager not found!");
        }
        if (fillImage != null)
        {
            // Initialize fillImage (optional, if using Image instead of Slider)
        }
        EnemyBehavior[] enemies = FindObjectsOfType<EnemyBehavior>();
        enemyCount = enemies.Length;
        totalHealth = totalHealth * enemyCount; // Adjust based on your max health (e.g., 20 for this case)
        if (gameManager != null)
        {
            gameManager.globalMaxHealth = (int)totalHealth;
            Debug.Log("EnemyHealthTracker synced globalMaxHealth to: " + gameManager.globalMaxHealth);
        }
    }

    public void ReduceHealth(float damage)
    {
        if (gameManager != null)
        {
            gameManager.ReduceGlobalHealth((int)damage);
            Debug.Log("Total health reduced to: " + (totalHealth - damage) + ", calling ReduceGlobalHealth with: " + damage);
        }
        else
        {
            Debug.LogWarning("gameManager is null");
        }
    }
}