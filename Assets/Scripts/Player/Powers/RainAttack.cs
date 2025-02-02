using UnityEngine;

public class RainAttack : AttackArea
{
    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        damage = (int) GlobalData.skillsData["Nuvem"][1];
        base.OnTriggerEnter2D(collider);
        
        if(collider.CompareTag("Ground") || collider.GetComponent<BossHP>() != null)
        {
            animator.Play("RainFall");
            Destroy(gameObject, animator.GetCurrentAnimatorClipInfo(0).Length + 0.2f);
        }
    }
}
