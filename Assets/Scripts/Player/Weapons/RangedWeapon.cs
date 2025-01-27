using UnityEngine;

abstract class RangedWeapon : Weapon
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    protected override void Attack()
    {
        base.Attack();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public override void ChangeAttackAreaModifiers()
    {
        AttackArea attackArea = bulletPrefab.GetComponent<Bullet>();
        attackArea.bananaSplitAmountOfHits = bananaSplitAmountOfHits;
        attackArea.bananaSplitEffect = bananaSplitEffect;
        attackArea.bananaSplitModifier = bananaSplitModifier;
        attackArea.damageModifier = damageModifier;
    }
}
