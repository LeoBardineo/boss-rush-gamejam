using System;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class TearJet : MonoBehaviour
{
    private float time, timeToDestroy, timeToShoot=1.5f, timeTracked, delayToShoot;
    private bool shooting;
    [SerializeField]
    public GameObject waterJetPrefab; // Prefab do jato de água
    [SerializeField]
    public GameObject waterTracePrefab;
    [SerializeField]
    public Transform waterJetSpawnPoint; // Ponto onde o jato será instanciado
    [SerializeField]
    public Transform player; // Referência ao jogador
    private GameObject waterTrace;
    private GameObject waterJet;
    private Vector3 direction, finalDirection;

    void Start()
    {
        InstantiateJetTrace();
    }
    void Update()
    {
        // time += Time.deltaTime;
        // timeToDestroy += Time.deltaTime;
        // if (time >= 3)
        // {
        //     time = 0;
        //     timeToDestroy=0;
        //     ShootWaterJet();
        // }

        // if (timeToDestroy >=1.5)
        // {

        //     Destroy(waterJet);
        
        // }
        PlayerTracking();

    }

    public void InstantiateJetTrace()
    {
        waterTrace = Instantiate(waterTracePrefab, waterJetSpawnPoint.position, Quaternion.identity);
        
    }

    public void PlayerTracking()
    {
        if (timeTracked < timeToShoot)
        {
        // Calcula a direção do jogador
        direction = (player.position - waterTrace.transform.position).normalized;
        // Calcula o ângulo para rotacionar o jato de água
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Rotaciona o jato de água no eixo Z
        waterTrace.transform.rotation = Quaternion.Euler(0, 0, angle);
        // Registrando passagem de tempo do tracing pra depois atirar.
        timeTracked += Time.deltaTime;
        }
        else
        {
            delayToShoot += 0.2f;
            if (delayToShoot > 85 && !shooting)
            {
                delayToShoot=0;
                Destroy(waterTrace);
                ShootWaterJet();
                shooting = true;
            }
        }
    }
    public void ShootWaterJet()
    {
        // Instancia o jato de água
        waterJet = Instantiate(waterJetPrefab, waterJetSpawnPoint.position, Quaternion.identity);
        // Calcula o ângulo para rotacionar o jato de água
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotaciona o jato de água no eixo Z
        waterJet.transform.rotation = Quaternion.Euler(0, 0, angle);
        shooting = false;
        // timeTracked = 0;
    }
}
