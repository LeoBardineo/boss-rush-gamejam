using UnityEngine;

public class OceanOfTears : BossDMG
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void  Start()
    {
        base.Start();
    }
    protected override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
    }
}
