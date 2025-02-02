using UnityEngine;

abstract class MeleeWeapon : Weapon
{
    [SerializeField]
    protected PlayerController PlayerControl;
    
    [SerializeField]
    protected AttackArea attackArea;

    [SerializeField]
    protected float attackWindow = 0.8f;

    [SerializeField]
    protected string attackingAnimation = "";
    [SerializeField] AudioSource sound;

    protected override void Attack()
    {
        sound.Play();
        base.Attack();
        attacking = true;
        attackArea.gameObject.SetActive(true);
        animator.Play(attackingAnimation);
        // attackWindow = animator.GetCurrentAnimatorStateInfo(0).length;
        Debug.Log(attackWindow);
    }

    protected override void HandleCooldown()
    {
        timer += Time.deltaTime;

        if (attacking && timer >= attackWindow)
        {
            timer = 0;
            attacking = false;
            attackArea.gameObject.SetActive(false);
        }

        if (!attacking && timer >= cooldownTime)
        {
            timer = 0;
            onCooldown = false;
        }
    }

    public override bool RetornaBananaSplitAtivo()
    {
        return attackArea.bananaSplitAmountOfHits > 0;
    }

    public override void ChangeAttackAreaModifiers()
    {
        attackArea.bananaSplitAmountOfHits = bananaSplitAmountOfHits;
        attackArea.bananaSplitEffect = bananaSplitEffect;
        attackArea.bananaSplitModifier = bananaSplitModifier;
        attackArea.damageModifier = damageModifier;
    }
}
