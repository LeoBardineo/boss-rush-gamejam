using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class BallHandAttack : MonoBehaviour
{
    [SerializeField]
    private float timer, antecipationTime=0.8f, vanishTimer, vanishCompleteTime=0.7f;
    [SerializeField]
    private GameObject leftHand,rightHand, rightToLeftLimitAndSpawn, leftToRightLimitAndSpawn;
    [Header("Speed")]
    [SerializeField] private float speed=3f;
    [SerializeField] private GameObject leftToRightResetGO,rightToLeftResetGO;
    private Rigidbody2D rbLeftHand, rbRightHand;
    private SpriteRenderer SpriteLeftHand, SpriteRightHand;
    public bool leftToRight, rightToLeft, antecipationStarted, antecipationFinished, canMove, vanishStarted, vanishFinished;
    //Basicamente vamo usar o int randAttackDirection pra fazer um random de 1 a 2, se 1 = leftToRight, se 2 =rightToLeft no ataque
    private int randAttackDirection;
    private Vector3 originalPosLeftHand, originalPosRightHand;


     public static bool ballHandAttacking= false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbLeftHand = leftHand.GetComponent<Rigidbody2D>();
        rbRightHand = rightHand.GetComponent<Rigidbody2D>();
        originalPosLeftHand = leftHand.transform.position;
        originalPosRightHand = rightHand.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartVanish();
        }

        if (vanishStarted)
        {
            if (vanishTimer<=vanishCompleteTime)
            {
                vanishTimer+= Time.deltaTime;
            }
            else
            {
                vanishFinished = true;
                vanishStarted = false;
                vanishTimer = 0f;
                moveHand();
            }
        }

        if (vanishFinished)
        {
            if (antecipationStarted)
            {
                if (timer<=antecipationTime)
                {
                    timer+= Time.deltaTime;
                }
                else
                {
                    antecipationFinished = true;
                    timer = 0f;
                    antecipationStarted = false;
                }        
            }
            else if (antecipationFinished && !ballHandAttacking)
            {
                StartBallAttack();
                antecipationFinished = false;
            }

            if (ballHandAttacking)
            {
                if(leftToRight && !leftHand.GetComponent<HandInfo>().resetHandPos)
                {
                    rbLeftHand.linearVelocity = new Vector2(speed*speed,rbLeftHand.linearVelocity.y);
                }
                else if(leftHand.GetComponent<HandInfo>().resetHandPos && !leftHand.GetComponent<HandInfo>().defaultHandPos)
                {
                    rbLeftHand.linearVelocity = new Vector2(-(speed*speed),rbLeftHand.linearVelocity.y);
                }
                else if (leftHand.GetComponent<HandInfo>().defaultHandPos)
                {
                    rbLeftHand.linearVelocity = new Vector2(0,0);
                    vanishFinished = false;
                    leftHand.transform.position= originalPosLeftHand;
                    leftHand.GetComponent<HandInfo>().ResetAll();
                    leftToRightResetGO.SetActive(false);
                    rightHand.SetActive(true);
                    leftToRight=false;
                    ballHandAttacking = false;
                }
                if(rightToLeft && !rightHand.GetComponent<HandInfo>().resetHandPos)
                {
                    rbRightHand.linearVelocity = new Vector2(-(speed*speed),rbRightHand.linearVelocity.y);
                }
                else if(rightHand.GetComponent<HandInfo>().resetHandPos && !rightHand.GetComponent<HandInfo>().defaultHandPos)
                {
                    rbRightHand.linearVelocity = new Vector2(speed*speed,rbRightHand.linearVelocity.y);
                }
                else if (rightHand.GetComponent<HandInfo>().defaultHandPos)
                {
                    rbRightHand.linearVelocity = new Vector2(0,0);
                    vanishFinished = false;
                    rightHand.transform.position= originalPosRightHand;
                    rightHand.GetComponent<HandInfo>().ResetAll();
                    rightToLeftResetGO.SetActive(false);
                    leftHand.SetActive(true);
                    rightToLeft= false;
                    ballHandAttacking = false;
                }
            }
        }
    }

    public void StartVanish()
    {
        vanishStarted = true;
    }

    private void moveHand()
    {
        StartAntecipation();
        int rand = Random.Range(1,3);
        Debug.Log("Rand number:"+rand);
        if(rand == 1)
        {
            leftToRight = true;
            leftToRightResetGO.SetActive(true);
        }
        else
        {
            rightToLeft = true;
            rightToLeftResetGO.SetActive(true);
        }
        if (leftToRight)
        {
            rightHand.SetActive(false);
            Vector3 targetPosition = leftToRightLimitAndSpawn.transform.position;;
            targetPosition.x += 1;
            leftHand.transform.position = targetPosition;
        }
        else if (rightToLeft)
        {
            leftHand.SetActive(false);
            Vector3 targetPosition = rightToLeftLimitAndSpawn.transform.position;
            targetPosition.x -= 1;
            rightHand.transform.position = targetPosition;
        }
    }

    public void StartBallAttack()
    {
        ballHandAttacking = true;
    }

    private void StartAntecipation()
    {
        antecipationStarted = true;
    }
}
