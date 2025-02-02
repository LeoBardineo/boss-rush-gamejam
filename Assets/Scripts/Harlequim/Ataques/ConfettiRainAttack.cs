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
    public float antecipationDuration = 2f, time=0, timeTrackingAfter=2f, timeT=0, timeD;
    public float attackDuration = 5f;
    public float spawnInterval = 14f;
    public static bool isAttacking = false;
    private bool spawnHasBegun=false, posSpawnTracking=false;
    [SerializeField]
    private float trackingSpeed=0.12f;
    [SerializeField] private Animator AnimLeftHand,AnimRightHand;

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
                    time=0;
                }
            }
        }
        if(isAttacking)
        {
            if (timeD<=attackDuration && timeD>=4.5)
            {
                if(isRightHand)
            {
                AnimRightHand.Play("closedRightHand");
            }
            else
            {
                AnimLeftHand.Play("closedLeftHand");
            }
            }
            if(timeD<=attackDuration)
            {
                timeD+=Time.deltaTime;
            }
            else
            {
                timeD=0;
                EndAttack();
                isAttacking = false;
            }
        }
    }

    public void StartSpawning()
    {
        spawnHasBegun = true;
            if (isRightHand)
        {
            AnimRightHand.Play("openRightHand");
            Instantiate(confettiPrefab, rightHand);
        }
        else
        {
            AnimLeftHand.Play("openLeftHand");
            Instantiate(confettiPrefab, leftHand);
        }
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
        Debug.Log("Tracking");
        if(!posSpawnTracking)
        {
            if(isRightHand)
            {
                AnimRightHand.Play("closedRightHand");
            }
            else
            {
                AnimLeftHand.Play("closedLeftHand");
            }
        }

        if (isRightHand)
        { 
            // Vector3 playerTrackPos = new Vector3(player.position.x,rightHand.position.y,rightHand.position.z);
            // player.position = playerTrackPos;
            rightHand.position = Vector3.SmoothDamp(rightHand.position, playerTracking.position ,ref velocity, trackingSpeed);
            posicaoCentro = rightHand.position;
            dimensoes = rightHand.localScale / 2;
        }
        else if(!isRightHand)
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

    void EndAttack()
    {
        isAttacking = false;
        spawnHasBegun = false;
        if (isRightHand)
        {
            AnimRightHand.Play("idleRightLeft");
        }
        else
        {
            AnimLeftHand.Play("idle");
        }
        returnDefault();
    }
}
