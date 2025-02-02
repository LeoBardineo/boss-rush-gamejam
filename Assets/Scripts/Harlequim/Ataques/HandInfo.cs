using JetBrains.Annotations;
using UnityEngine;

public class HandInfo : MonoBehaviour
{
    public bool resetHandPos = false, handStartPlace = false, defaultHandPos, finishedCicle, touchedLimit;
    protected float bossDMG;
    protected virtual void  Start()
    {
        bossDMG = GlobalData.bossData["Dano"][GlobalData.level];
    }
    
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerHP>() != null && GlobalData.playerCanTakeDamage)
            {
                PlayerHP playerHP = collision.GetComponent<PlayerHP>();
                if (!playerHP.invicible)
                {
                    playerHP.TakeDamage(bossDMG);
                }
            }
        } 
    
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

        protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerHP>() != null && GlobalData.playerCanTakeDamage)
            {
                PlayerHP playerHP = collision.GetComponent<PlayerHP>();
                if (!playerHP.invicible)
                {
                    playerHP.TakeDamage(bossDMG);
                }
            }
        } 
    }
    // protected override void OnTriggerEnter2D(Collider2D collision) {
    //     if(collision.GetComponent<PlayerHP>()!= null)
    //     {
    //         if(GlobalData.playerCanTakeDamage)
    //         {
    //             Debug.Log("Tomou dano player");
    //             base.OnTriggerEnter2D(collision);
    //         }
    //     }
    //     if (collision.CompareTag("ResetHand"))
    //     {
    //         resetHandPos = true;
    //         defaultHandPos = false;
    //     }
    //     if (collision.CompareTag("DefaultHand"))
    //     {
    //         defaultHandPos = true;
    //         finishedCicle = true;
    //     }

    // }

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