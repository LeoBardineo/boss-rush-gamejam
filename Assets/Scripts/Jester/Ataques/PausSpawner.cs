using System.Collections.Generic;
using UnityEngine;

public class PausSpawner : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject spawnArea;
    public PausCard pausCard;
    public PlayerController playerController;
    public List<Transform> spawnPositionList;
    public static bool cardSpawned = false;
    GameObject pausCardInstanciado;

    void Start()
    {
        pausCard = cardPrefab.GetComponent<PausCard>();
        foreach(Transform transform in spawnArea.transform)
            spawnPositionList.Add(transform);
    }

    public void SpawnCard()
    {
        Vector3 spawnPosition = spawnPositionList[Random.Range(0, spawnPositionList.Count)].position;
        pausCard.playerController = playerController;
        pausCardInstanciado = Instantiate(cardPrefab, spawnPosition, cardPrefab.transform.rotation);
        cardSpawned = true;
    }

    public void StartReverse()
    {
        pausCardInstanciado.GetComponent<PausCard>().ReverseControls();
    }
}
