using UnityEngine;

public class ConfettiDMG : BossDMG
{
    public int damageAmount = 10;
    private float time, timeToDestroy=2.4f;
    protected override void  Start()
    {
        base.Start();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

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
