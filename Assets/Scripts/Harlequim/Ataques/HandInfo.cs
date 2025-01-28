using UnityEngine;

public class HandInfo : BossDMG
{
    public bool resetHandPos = false, handStartPlace = false, defaultHandPos, finishedCicle, touchedLimit;
    protected override void  Start()
    {
        base.Start();
    }

    void Update()
    {

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

    public void ResetBoolHandPos()
    {
        resetHandPos = false;        
    }

    public void ResetDefaultHandPos()
    {
        defaultHandPos = false;
    }

    public void FinishedCicleReset()
    {
        finishedCicle = false;
    }

    public void ResetAll()
    {
        resetHandPos = false;
        finishedCicle = false;
        defaultHandPos = false;  
    }
}