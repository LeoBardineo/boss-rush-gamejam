using UnityEngine;

public class RainTears : BossDMG
{
    public int damageAmount = 10;
    public float time, timeToDestroy=4f;
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
    void Update()
    {
        if (time <= timeToDestroy)
        {
            time+=Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
            time=0;
        }
    }
}
