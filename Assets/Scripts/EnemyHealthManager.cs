using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    public Slider healthBar;
    private int totalEnemyHealth = 20; // Initial health for the collective enemies

    public int TotalEnemyHealth
    {
        get { return totalEnemyHealth; }
    }

    void Start()
    {
        if (healthBar != null)
        {
            healthBar.maxValue = totalEnemyHealth;
            healthBar.value = totalEnemyHealth;
        }
    }

    public void ReduceHealth(int damage)
    {
        totalEnemyHealth -= damage;
        Debug.Log(totalEnemyHealth);
        if (healthBar != null)
        {
            healthBar.value = Mathf.Max(0, totalEnemyHealth); // Ensure value doesn’t go negative
        }
        if (totalEnemyHealth <= 0)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.PlayerWin();
            }
        }
    }
}