using UnityEngine;

public class ClappingAttack : MonoBehaviour
{
    private Rigidbody2D rbLeftHand,rbRightHand;
    [SerializeField] private GameObject leftHand,rightHand;
    [SerializeField] private float clappingSpeed=3.5f;
    [SerializeField] private Transform leftHandClapPos,rightHandClapPos;
    [SerializeField] private Vector3 originalLeftHandPos,originalRightHandPos;
    [SerializeField] private SpriteRenderer leftHandSprite, rightHandSprite;
    [SerializeField] private float antecipationTimer=3f, timer;

    public static bool clapping = false;
    public bool canClap=false, antecipationStarted, canBegingClap, antecipationFinished;
    public int ciclesOfClaps, currentCicle;
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
                timer+= 0.1f;
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
        targetPosition.x += 3;
        originalLeftHandPos = leftHand.transform.position;
        originalRightHandPos= rightHand.transform.position;
        //Movendo elas para posição do Clap.
        leftHand.transform.position = targetPosition;
        targetPosition = rightHandClapPos.position;
        targetPosition.x -= 3;
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
