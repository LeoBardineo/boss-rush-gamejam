using UnityEngine;

public class RainAttack : AttackArea
{
    Animator animator;
    Rigidbody2D rb;
    bool deuDano = false;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        damage = (int) GlobalData.skillsData["Nuvem"][1];

        if(!deuDano)
            base.OnTriggerEnter2D(collider);
        
        bool chao = collider.CompareTag("Ground");
        bool boss = collider.GetComponent<BossHP>() != null;
        
        if(boss)
        {
            deuDano = true;
        }

        if(chao)
        {
            animator.Play("RainFall");
            rb.gravityScale = 0;
            rb.linearVelocity = new Vector3(0, 0, 0);
            Destroy(gameObject, animator.GetCurrentAnimatorClipInfo(0).Length - 0.4f);
        }
    }
}
