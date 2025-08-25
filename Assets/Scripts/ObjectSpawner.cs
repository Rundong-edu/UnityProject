using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 1f;
    private float spawnTimer;

    void Start()
    {
        spawnTimer = spawnInterval;
        Debug.Log("ObjectSpawner Start - enemyPrefab assigned: " + (enemyPrefab != null) + ", Name: " + (enemyPrefab != null ? enemyPrefab.name : "null"));
        if (enemyPrefab != null && !enemyPrefab.activeInHierarchy) // Check if it's a prefab (not in scene)
        {
            Debug.Log("Confirmed enemyPrefab is a prefab, not a scene object.");
        }
        else if (enemyPrefab != null)
        {
            Debug.LogWarning("enemyPrefab is a scene object, not a prefab. Consider using a prefab instead.");
        }
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnObject();
            spawnTimer = spawnInterval;
        }
    }

    public void SpawnObject()
    {
        Debug.Log("Attempting to spawn - enemyPrefab: " + (enemyPrefab != null) + ", Name: " + (enemyPrefab != null ? enemyPrefab.name : "null"));
        if (enemyPrefab != null)
        {
            try
            {
                float randomX = Random.Range(-7f, 7f);
                GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(randomX, 6f, 0), Quaternion.identity);
                if (newEnemy != null)
                {
                    Debug.Log("Enemy spawned at: " + newEnemy.transform.position + ", Name: " + newEnemy.name);
                }
                else
                {
                    Debug.LogError("Instantiate returned null, prefab may be invalid.");
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Instantiation failed: " + e.Message);
            }
        }
        else
        {
            Debug.LogError("enemyPrefab is not assigned or has been destroyed!");
        }
    }

    public void OnGameOver()
    {
        Debug.Log("ObjectSpawner received GameOver, stopping spawns");
        enabled = false; // Disable the spawner to stop further updates
    }

    public void OnGameWin()
    {
        Debug.Log("ObjectSpawner received GameWin, stopping spawns");
        enabled = false; // Disable the spawner to stop further updates
    }
}
