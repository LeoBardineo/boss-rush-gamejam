using UnityEngine;

public class TargetPlayer : BossDMG
{
    protected override void  Start()
    {
        base.Start();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
