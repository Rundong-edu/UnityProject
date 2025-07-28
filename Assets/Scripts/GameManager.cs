using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverText;
    private int score = 0;
    private bool gameOver = false;

    void Start()
    {
        scoreText.text = "Score: " + score;
        gameOverText.gameObject.SetActive(false);
    }

    public void AddScore()
    {
        if (!gameOver)
        {
            score++;
            scoreText.text = "Score: " + score;
        }
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true);
        // Stop spawning (optional: cancel InvokeRepeating in Spawner)
    }
}