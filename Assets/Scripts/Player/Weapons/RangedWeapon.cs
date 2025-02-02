using System.Collections;
using UnityEngine;

abstract class RangedWeapon : Weapon
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    [SerializeField]
    string animationName;

    protected override void Attack()
    {
        base.Attack();
        animator.Play(animationName);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        StartCoroutine(WaitAnimation());
    }

    IEnumerator WaitAnimation()
    {
        attacking = true;
        yield return new WaitForSeconds(0.5f);
        attacking = false;
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
