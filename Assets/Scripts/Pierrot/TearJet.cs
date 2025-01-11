using System;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class TearJet : MonoBehaviour
{
    //Caso queira aumentar o tempo que a atencipação do ataque dura aumentar o timeToShoot.
    //Caso queira aumenar o tempo que o ataque em si dura(a jatada) aumentar o timeAfterShoot.
    // Caso queira invocar um jato para motivos de teste e debug é só apertar O.
    private float time,timeTracked, delayToShoot;
    [SerializeField]
    private float timeAfterShoot=2.0f, timeToShoot=1.5f;
    private bool shooting, canTraceTrack, shootComplete;
    [SerializeField]
    public GameObject waterJetPrefab, waterTracePrefab; // Prefab do jato de água e da antecipação
    [SerializeField]
    public Transform waterJetSpawnPoint, player; // Ponto onde o jato será instanciado e a referencia da posição do player
    private GameObject waterTrace;
    private GameObject waterJet;
    private Vector3 direction, finalDirection;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            InstantiateJetTrace();
        }

        if (canTraceTrack)
        {
            PlayerTracking();
        }
        
        if (time <= timeAfterShoot && shootComplete)
        {
            time+= Time.deltaTime;
        }
        else
        {
            time=0;
            shootComplete=false;
            Destroy(waterJet);
        }
        

    }

    public void InstantiateJetTrace()
    {
        waterTrace = Instantiate(waterTracePrefab, waterJetSpawnPoint.position, Quaternion.identity);
        canTraceTrack = true;
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
            if (delayToShoot > 65 && !shooting)
            {
                delayToShoot=0;
                shooting = true;
                canTraceTrack = false;  
                timeTracked=0;
                ShootWaterJet();
                Destroy(waterTrace);
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
        shootComplete = true;
    }
}
