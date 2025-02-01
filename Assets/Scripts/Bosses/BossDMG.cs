using UnityEngine;
using UnityEngine.Rendering;

public class BossDMG : MonoBehaviour
{
    protected float bossDMG;

    protected virtual void  Start()
    {
        bossDMG = GlobalData.bossData["Dano"][GlobalData.level];
    }
    
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerHP>() != null)
            {
                PlayerHP playerHP = collision.GetComponent<PlayerHP>();
                if (!playerHP.invicible)
                {
                    playerHP.TakeDamage(bossDMG);
                }
            }
        } 
    }

        protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerHP>() != null)
            {
                PlayerHP playerHP = collision.GetComponent<PlayerHP>();
                if (!playerHP.invicible)
                {
                    playerHP.TakeDamage(bossDMG);
                }
            }
        } 
    }
}
