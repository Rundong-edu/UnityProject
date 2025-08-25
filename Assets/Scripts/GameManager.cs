using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int globalMaxHealth = 20; 
    private int currentGlobalHealth;
    public ObjectSpawner objectSpawner;
    public GameObject winCanvas;
    public GameObject gameOverCanvas;

    public bool gameEnded { get; private set; } = false;  // NEW FLAG

    public int CurrentGlobalHealth
    {
        get { return currentGlobalHealth; }
    }

    void Start()
    {
        currentGlobalHealth = globalMaxHealth;
        Debug.Log("GameManager initialized with globalMaxHealth: " + globalMaxHealth + " (Inspector value), currentGlobalHealth: " + currentGlobalHealth);
        if (winCanvas != null) winCanvas.SetActive(false);
        if (gameOverCanvas != null) gameOverCanvas.SetActive(false);
    }

    public void ReduceGlobalHealth(int damage)
    {
        if (gameEnded) return; // ignore if game already ended

        currentGlobalHealth -= damage;
        currentGlobalHealth = Mathf.Max(0, currentGlobalHealth);
        Debug.Log("Global health reduced by " + damage + ", new value: " + currentGlobalHealth);

        if (currentGlobalHealth <= 0)
        {
            Debug.Log("Health reached 0 or below, triggering PlayerWin");
            PlayerWin();
        }
    }

    public void GameOver()
    {
        if (gameEnded) return;
        gameEnded = true;

        Debug.Log("Game Over");
        if (gameOverCanvas != null) gameOverCanvas.SetActive(true);
        if (objectSpawner != null) objectSpawner.OnGameOver();
    }

    public void PlayerWin()
    {
        if (gameEnded) return;
        gameEnded = true;

        Debug.Log("Player Wins - Activating winCanvas");
        if (winCanvas != null) winCanvas.SetActive(true);
        if (objectSpawner != null) objectSpawner.OnGameWin();
    }
}
