using UnityEngine;

public class HandInfo : BossDMG
{
    public bool resetHandPos = false, handStartPlace = false, defaultHandPos, finishedCicle;
    protected override void  Start()
    {
        base.Start();
    }
    protected override void OnTriggerEnter2D(Collider2D collision) {
        base.OnTriggerEnter2D(collision);
        if (collision.CompareTag("ResetHand"))
        {
            resetHandPos = true;
            defaultHandPos = false;
        }
        if (collision.CompareTag("DefaultHand"))
        {
            defaultHandPos = true;
            finishedCicle = true;
        }
    }

    public void StartCicle()
    {
        resetHandPos = false;
        finishedCicle = false;
    }
}
