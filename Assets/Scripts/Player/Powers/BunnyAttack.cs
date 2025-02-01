using UnityEngine;

public class BunnyAttack : AttackArea
{
    public float velocidadeDeGiro, velocidadeDeMovimeto;

    void Start()
    {
        damage = (int) GlobalData.skillsData["Coelhos"][1];
    }

    void Update()
    {
        transform.Rotate(0f, 0f, velocidadeDeGiro * Time.deltaTime);
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
