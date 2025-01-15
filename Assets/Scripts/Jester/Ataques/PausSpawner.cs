using System.Collections.Generic;
using UnityEngine;

public class PausSpawner : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject spawnArea;
    public PlayerController playerController;
    public List<Transform> spawnPositionList;
    public static bool cardSpawned = false;

    void Start()
    {
        foreach(Transform transform in spawnArea.transform)
            spawnPositionList.Add(transform);
    }

    public void SpawnCard()
    {
        Vector3 spawnPosition = spawnPositionList[Random.Range(0, spawnPositionList.Count)].position;
        cardPrefab.GetComponent<PausCard>().playerController = playerController;
        Instantiate(cardPrefab, spawnPosition, cardPrefab.transform.rotation);
        cardSpawned = true;
    }
}
