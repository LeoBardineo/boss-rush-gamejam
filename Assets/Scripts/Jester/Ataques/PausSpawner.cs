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
    public static GameObject pausCardInstanciado;
    public BossHP bossHP;
    PlataformaSpawner plataformaSpawner;

    void Start()
    {
        pausCard = cardPrefab.GetComponent<PausCard>();
        plataformaSpawner = GetComponent<PlataformaSpawner>();
    }

    public void SpawnCard()
    {
        spawnPositionList = new List<Transform>();
        for(int i = 0; i < spawnArea.transform.childCount; i++)
        {
            if(i % 3 == plataformaSpawner.posAtual) continue;
            Transform spawnPos = spawnArea.transform.GetChild(i);
            spawnPositionList.Add(spawnPos);
        }
        
        Vector3 spawnPosition = spawnPositionList[Random.Range(0, spawnPositionList.Count)].position;
        pausCard.playerController = playerController;
        pausCard.bossHP = bossHP;
        pausCardInstanciado = Instantiate(cardPrefab, spawnPosition, cardPrefab.transform.rotation);
        cardSpawned = true;
    }

    public void StartReverse()
    {
        pausCardInstanciado.GetComponent<PausCard>().ReverseControls();
    }

    public static void StopAttack(PlayerController playerController)
    {
        cardSpawned = false;
        Destroy(pausCardInstanciado);
        playerController.speed *= -1;
        playerController.transform.Rotate(0f,-180f,0f);
    }

}
