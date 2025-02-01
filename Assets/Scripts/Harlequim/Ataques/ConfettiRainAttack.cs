using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ConfettiRainAttack : MonoBehaviour
{
    public GameObject confettiPrefab;
    public Transform spawnRightHand,spawnLeftHand;
    [SerializeField] private Transform confettiLeftPos, confettiRightPos, defaultRightHandPos, defaultLeftHandPos, rightHand, leftHand, player, playerTracking;
    private bool isRightHand, tracking;
    private Vector3 posicaoCentro, dimensoes, velocity= Vector3.zero;
    public float spawnHeight = 1.5f;
    public float positionVariance = 0.5f;
    public float antecipationDuration = 2f, time=0, timeTrackingAfter=5f, timeT=0;
    public float attackDuration = 5f;
    public float spawnInterval = 0.1f;
    public static bool isAttacking = false;
    private bool spawnHasBegun=false, posSpawnTracking=false;
    [SerializeField]
    private float trackingSpeed=0.15f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            BeginAttack();
        }

        if (tracking)
        {
            trackPlayer();
            if (time <= antecipationDuration)
            {
                time += Time.deltaTime;
            }
            else
            {
                if (!spawnHasBegun && isAttacking)
                {
                    posSpawnTracking = true;
                    StartSpawning();
                }
            }

            if (posSpawnTracking)
            {
                if(timeT<= timeTrackingAfter)
                {
                    timeT += Time.deltaTime;
                }
                else
                {
                    timeT= 0;
                    tracking = false;
                    posSpawnTracking=false;
                }
            }

        }
    }

    public void StartSpawning()
    {
        spawnHasBegun = true;
        InvokeRepeating(nameof(SpawnConfetti), antecipationDuration, spawnInterval);
        StartCoroutine(WaitSpawning(antecipationDuration + attackDuration));
    }

    void SpawnConfetti()
    {
        Vector3 posicaoAleatoria = new Vector3(posicaoCentro.x, posicaoCentro.y, posicaoCentro.z);
        Instantiate(confettiPrefab, posicaoAleatoria, confettiPrefab.transform.rotation);
    }

    IEnumerator WaitSpawning(float attackDuration)
    {
        yield return new WaitForSeconds(attackDuration);
        CancelInvoke(nameof(SpawnConfetti));
        isAttacking = false;
        spawnHasBegun = false;
        returnDefault();
        Debug.Log("testes wait spawn");
    }

    void moveHandUp(bool hand)
    {
        if(hand)
        {
           rightHand.transform.position = confettiRightPos.position;
        } 
        else
        {
            leftHand.transform.position = confettiLeftPos.position;
        }
    }

    void trackPlayer()
    {
        if (isRightHand)
        { 
            // Vector3 playerTrackPos = new Vector3(player.position.x,rightHand.position.y,rightHand.position.z);
            // player.position = playerTrackPos;
            rightHand.position = Vector3.SmoothDamp(rightHand.position, playerTracking.position ,ref velocity, trackingSpeed);
            posicaoCentro = rightHand.position;
            dimensoes = rightHand.localScale / 2;
        }
        else
        {
            leftHand.position = Vector3.SmoothDamp(leftHand.position, playerTracking.position,ref velocity, trackingSpeed);
            posicaoCentro = leftHand.position;
            dimensoes = leftHand.localScale / 2;
        }
    }

    public void BeginAttack()
    {
        isAttacking = true;
        int rand = Random.Range(1,3);
        if (rand==1)
        {
            isRightHand = true;
            moveHandUp(isRightHand);
        }
        else
        {
            isRightHand = false;
            moveHandUp(isRightHand);
        }
        tracking = true;
    }
    
    void returnDefault()
    {
        if (isRightHand)
        {
            rightHand.position = defaultRightHandPos.position;
        }
        else
        {
            leftHand.position = defaultLeftHandPos.position;
        }
    }
}
