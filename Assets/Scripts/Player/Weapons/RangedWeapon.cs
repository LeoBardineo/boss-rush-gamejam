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
}
