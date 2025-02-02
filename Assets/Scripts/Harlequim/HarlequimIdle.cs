using UnityEngine;

public class HarlequimIdle : MonoBehaviour
{
    private bool onIdle;
    [SerializeField] Animator harlequim, hand1, hand2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalData.harlequimIdle && !onIdle)
        {
            harlequim.Play("HarlequimIdle");
            hand1.Play("idle");
            hand2.Play("idleRightLeft");
            onIdle = true;
        }
    }
}
