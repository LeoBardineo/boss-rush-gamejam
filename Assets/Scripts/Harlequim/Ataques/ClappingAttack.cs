using UnityEngine;

public class ClappingAttack : MonoBehaviour
{
    [SerializeField] private float clappingSpeed=3.5f;
    [SerializeField] private float antecipationTimer=1.2f, timer;
    private Rigidbody2D rbLeftHand,rbRightHand;
    [SerializeField] private GameObject leftHand,rightHand;
    [SerializeField] private GameObject SlapReset;
    [SerializeField] private Transform leftHandClapPos,rightHandClapPos;
    private Vector3 originalLeftHandPos,originalRightHandPos;
    [SerializeField] private SpriteRenderer leftHandSprite, rightHandSprite;
    public static bool clapping = false;
    private bool canClap=false, antecipationStarted, canBegingClap, antecipationFinished;

    [SerializeField]
    private int ciclesOfClaps, currentCicle;
    void Start()
    {
        currentCicle = 0;
        rbLeftHand = leftHand.GetComponent<Rigidbody2D>();
        rbRightHand = rightHand.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            BeginClapAttack();
        }

        if (antecipationStarted)
        {
            if (timer<=antecipationTimer)
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
        else
        {
        if (canClap && antecipationFinished)
        {
            if(!leftHand.GetComponent<HandInfo>().resetHandPos)
            {
                Debug.Log("TESTE");
            rbLeftHand.linearVelocity = new Vector2(clappingSpeed * clappingSpeed,rbLeftHand.linearVelocity.y);
            rbRightHand.linearVelocity = new Vector2(-(clappingSpeed * clappingSpeed),rbRightHand.linearVelocity.y);
            }
            else
            {
                if(!leftHand.GetComponent<HandInfo>().defaultHandPos && !leftHand.GetComponent<HandInfo>().finishedCicle)
                {
                    rbLeftHand.linearVelocity = new Vector2(-(clappingSpeed * clappingSpeed),rbLeftHand.linearVelocity.y);
                    rbRightHand.linearVelocity = new Vector2(clappingSpeed * clappingSpeed,rbRightHand.linearVelocity.y);
                    Debug.Log("ReturningCicle");
                }
                else
                {
                    rbLeftHand.linearVelocity = new Vector2(0,0);
                    rbRightHand.linearVelocity = new Vector2(0,0);                  
                    Debug.Log("Stoped!");
                    currentCicle +=1;
                    if (currentCicle >= ciclesOfClaps)
                    {
                       canClap = false;
                       currentCicle = 0; 
                       clapping = false;
                       MoveHandsToOriginalPosition();
                       antecipationFinished = false;
                       leftHand.GetComponent<HandInfo>().ResetAll();
                       rightHand.GetComponent<HandInfo>().ResetAll();
                       SlapReset.SetActive(false);
                     
                    }
                    else
                    {
                    leftHand.GetComponent<HandInfo>().StartCicle();
                    rightHand.GetComponent<HandInfo>().StartCicle();
                    }
                }
            }
        }
        }

    }

    public void BeginClapAttack()
    {
        SlapReset.SetActive(true);
        MoveHandsToClapPosition();
        leftHand.GetComponent<HandInfo>().StartCicle();
        rightHand.GetComponent<HandInfo>().StartCicle();
        ciclesOfClaps = Random.Range(1,5);
        clapping = true;
        if (!leftHand.GetComponent<HandInfo>().resetHandPos && !leftHand.GetComponent<HandInfo>().finishedCicle
        && !rightHand.GetComponent<HandInfo>().resetHandPos && !rightHand.GetComponent<HandInfo>().finishedCicle)
        {
            canClap = true;
        }
        else
        {
            canClap = false;
        }
    }

    void MoveHandsToClapPosition()
    {
        antecipationStarted = true;
        leftHandSprite.enabled = false;
        rightHandSprite.enabled = false;
        Vector3 targetPosition = leftHandClapPos.position;
        targetPosition.x += 1;
        originalLeftHandPos = leftHand.transform.position;
        originalRightHandPos= rightHand.transform.position;
        //Movendo elas para posição do Clap.
        leftHand.transform.position = targetPosition;
        targetPosition = rightHandClapPos.position;
        targetPosition.x -= 1;
        rightHand.transform.position = targetPosition;
        leftHandSprite.enabled = true;
        rightHandSprite.enabled = true;
    }

    void MoveHandsToOriginalPosition()
    {
        Debug.Log("Original position called");
        leftHand.transform.position = originalLeftHandPos;
        rightHand.transform.position = originalRightHandPos;
    }
}
