using UnityEngine;

public class RainTears : BossDMG
{
    public int damageAmount = 10;
    protected override void  Start()
    {
        base.Start();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if(collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
