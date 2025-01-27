using UnityEngine;

public class ClappingAttack : MonoBehaviour
{
    private Rigidbody2D rbLeftHand,rbRightHand;
    [SerializeField] private GameObject leftHand,rightHand; 
    [SerializeField] private float clappingSpeed;
    public static bool clapping = false;
    public bool canClap=false;
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

        if (canClap)
        {
            if(!leftHand.GetComponent<HandInfo>().resetHandPos)
            {
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

    public void BeginClapAttack()
    {
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

}
