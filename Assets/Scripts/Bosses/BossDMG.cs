using UnityEngine;
using UnityEngine.Rendering;

public class BossDMG : MonoBehaviour
{
    protected float bossDMG;

    protected virtual void  Start()
    {
        if (GlobalData.level == 0 || GlobalData.level == 1)
        {
            bossDMG = 0.5f;
        }
        if (GlobalData.level == 2)
        {
            bossDMG = 1f;
        }
        if (GlobalData.level == 3)
        {
            bossDMG = 1.5f;
        }
        if (GlobalData.level == 4)
        {
            bossDMG = 2f;
        }
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
}
