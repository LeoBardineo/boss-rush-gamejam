using UnityEngine;

abstract class MeleeWeapon : Weapon
{
    public bool attacking = false;

    [SerializeField]
    protected PlayerController PlayerControl;
    
    [SerializeField]
    protected AttackArea attackArea;

    [SerializeField]
    protected float attackWindow = 0.25f;

    protected override void Attack()
    {
        base.Attack();
        attacking = true;
        attackArea.gameObject.SetActive(true);
    }

    protected override void HandleCooldown()
    {
        timer += Time.deltaTime;

        if (attacking && timer >= attackWindow)
        {
            timer = 0;
            attacking = false;
            attackArea.gameObject.SetActive(false);
            return;
        }

        if (!attacking && timer >= cooldownTime)
        {
            timer = 0;
            onCooldown = false;
        }
    }
    
    public override void ChangeAttackAreaModifiers()
    {
        attackArea.bananaSplitAmountOfHits = bananaSplitAmountOfHits;
        attackArea.bananaSplitEffect = bananaSplitEffect;
        attackArea.bananaSplitModifier = bananaSplitModifier;
        attackArea.damageModifier = damageModifier;
    }
}
