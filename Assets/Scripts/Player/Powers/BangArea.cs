using UnityEngine;

public class BangArea : AttackArea
{
    public float velocidadeDeMovimeto;

    [SerializeField]
    int bangDamage;

    void Start()
    {
        damage = bangDamage;
    }

    void Update()
    {
        transform.position += new Vector3(velocidadeDeMovimeto * Time.deltaTime, 0, 0);
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
    }
    
    void OnBecameInvisible()
    {
        Destroy(gameObject, 0.5f);
    }
}
