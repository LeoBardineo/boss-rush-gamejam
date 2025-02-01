using UnityEngine;

public class WaveCollision : BossDMG
{

    private float time, timeToDestroy=2.9f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void  Start()
    {
        base.Start();
    }

    void Update()
    {
        if (time<=timeToDestroy)
        {
            time += Time.deltaTime;
        }
        else
        {
            time=0;
            Destroy(gameObject);
        }
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        Debug.Log("Wave DMG");
    }
}
