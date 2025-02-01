using Unity.VisualScripting;
using UnityEngine;

public class Bullet : AttackArea
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        damage = (int) GlobalData.weaponsData["Canhao"][GlobalData.level];

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
