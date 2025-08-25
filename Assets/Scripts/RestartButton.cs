using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void RestartGame()
    {
        Debug.Log("Restart button clicked!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reloads current scene
    }
}