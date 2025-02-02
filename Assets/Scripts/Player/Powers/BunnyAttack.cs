using UnityEngine;

public class BunnyAttack : AttackArea
{
    public float velocidadeDeMovimeto;
    Animator animator;

    void Start()
    {
        damage = (int) GlobalData.skillsData["Coelhos"][1];
        animator = GetComponent<Animator>();
        Destroy(gameObject, animator.GetCurrentAnimatorClipInfo(0).Length + 0.2f);
    }

    void Update()
    {
        // transform.Rotate(0f, 0f, velocidadeDeGiro * Time.deltaTime);
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
