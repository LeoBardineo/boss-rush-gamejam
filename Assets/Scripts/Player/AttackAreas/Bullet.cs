using Unity.VisualScripting;
using UnityEngine;

public class Bullet : AttackArea
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GlobalData.level == 0)
        {
            damage = 30;
        }
        if (GlobalData.level == 1)
        {
            damage = 32;
        }
        if (GlobalData.level == 2)
        {
            damage = 35;
        }
        if (GlobalData.level == 3)
        {
            damage = 38;
        }
        if (GlobalData.level == 4)
        {
            damage = 41;
        }

        rb.linearVelocity = transform.right * speed;   
    }

    // Update is called once per frame
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
        if (collider.GetComponent<BossHP>() != null)
        {
            Destroy(gameObject);
        }
    }
    
    void OnBecameInvisible()
    {
        Destroy(gameObject, 0.5f);
    }
}
