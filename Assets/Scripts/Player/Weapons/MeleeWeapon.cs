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

        if (timer >= attackWindow)
        {
            timer = 0;
            attacking = false;
            attackArea.gameObject.SetActive(false);
            return;
        }

        if (timer >= cooldownTime && !attacking)
        {
            timer = 0;
            onCooldown = false;
        }
    }
}
