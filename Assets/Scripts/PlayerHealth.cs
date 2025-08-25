using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public Image[] healthIcons;
    public ObjectSpawner objectSpawner;
    private GameManager gameManager;
    public GameObject gameOverCanvas; // Reference to GameOverCanvas
    private float damageCooldown = 0.5f; // 0.5 seconds cooldown
    private float lastDamageTime;

    void Start()
    {
        currentHealth = maxHealth;
        gameManager = FindObjectOfType<GameManager>();
        gameOverCanvas.SetActive(false); // Ensure GameOverCanvas is hidden
        Debug.Log("PlayerHealth Start - GameManager found: " + (gameManager != null));
        if (healthIcons == null || healthIcons.Length == 0)
        {
            Debug.LogError("Health Icons array is null or empty!");
        }
        UpdateHealthDisplay();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && currentHealth > 0 && Time.time - lastDamageTime >= damageCooldown)
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Taking damage: " + damage + ", Stack trace: " + new System.Diagnostics.StackTrace().ToString());
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        Debug.Log("Health reduced to: " + currentHealth);
        UpdateHealthDisplay();
        lastDamageTime = Time.time; // Update the last damage time

        if (currentHealth <= 0)
        {
            if (gameManager != null) gameManager.GameOver();
            gameOverCanvas.SetActive(true); // Show GameOverCanvas
            if (objectSpawner != null) objectSpawner.OnGameOver();
        }
    }

    void UpdateHealthDisplay()
    {
        for (int i = 0; i < healthIcons.Length; i++)
        {
            if (healthIcons[i] != null)
            {
                healthIcons[i].enabled = (i < currentHealth);
            }
        }
    }
}