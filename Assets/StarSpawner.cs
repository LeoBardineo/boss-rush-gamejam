using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab;
    public Transform spawnObject;
    public float spawnHeight = 1.5f;
    public float spawnInterval = 2f;
    public float positionVariance = 1.5f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnStar), 1f, spawnInterval);
    }

    void SpawnStar()
    {
        float randomX = Random.Range(-positionVariance, positionVariance);
        Vector3 spawnPosition = new Vector3(spawnObject.position.x + randomX, spawnObject.position.y + spawnHeight, spawnObject.position.z);
        Instantiate(starPrefab, spawnPosition, starPrefab.transform.rotation);
    }
}
