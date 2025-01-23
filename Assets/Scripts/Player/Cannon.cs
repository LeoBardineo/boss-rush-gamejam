using UnityEngine;
using UnityEngine.InputSystem;

public class Cannon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    protected bool attacking = false, onCooldown = false;
    protected float attackCooldown=2f, timer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !onCooldown)
        {
            Shoot();
            onCooldown = true;
        }

        if(attacking)
        {
            timer += Time.deltaTime;

            if (timer >= attackCooldown)
            {
                timer = 0;
                attacking = false;
                onCooldown = false;
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        attacking = true;
    }

}
