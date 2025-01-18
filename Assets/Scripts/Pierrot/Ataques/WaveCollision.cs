using UnityEngine;

public class WaveCollision : BossDMG
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void  Start()
    {
        base.Start();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        Debug.Log("Wave DMG");
    }
}
