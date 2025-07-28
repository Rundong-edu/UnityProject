using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject fallingObjectPrefab;
    public float spawnRate = 1f;
    private float minX = -7f;
    private float maxX = 7f;

    void Start()
    {
        InvokeRepeating("SpawnObject", 1f, spawnRate);
    }

    void SpawnObject()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, 6f, 0);
        GameObject obj = Instantiate(fallingObjectPrefab, spawnPosition, Quaternion.identity);
        Destroy(obj, 5f); // Remove object after 5 seconds
    }
}