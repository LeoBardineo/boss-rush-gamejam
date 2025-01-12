using System.Collections;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab;
    public Transform spawnObject;
    public float spawnHeight = 1.5f;
    public float positionVariance = 1.5f;
    public float antecipationDuration = 2f;
    public float attackDuration = 5f;
    public float spawnInterval = 0.1f;
    public bool isSpawning = false;

    public void StartSpawning()
    {
        isSpawning = true;
        InvokeRepeating(nameof(SpawnStar), antecipationDuration, spawnInterval);
    }

    void SpawnStar()
    {
        float randomX = Random.Range(-positionVariance, positionVariance);
        Vector3 spawnPosition = new Vector3(spawnObject.position.x + randomX, spawnObject.position.y + spawnHeight, spawnObject.position.z);
        Instantiate(starPrefab, spawnPosition, starPrefab.transform.rotation);
    }

    public void EndSpawning()
    {
        StartCoroutine(WaitSpawning(attackDuration));
    }

    IEnumerator WaitSpawning(float attackDuration)
    {
        yield return new WaitForSeconds(attackDuration);
        CancelInvoke(nameof(SpawnStar));
        isSpawning = false;
    }
}
