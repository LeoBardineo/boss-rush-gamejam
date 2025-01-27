using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected float cooldownTime;

    protected bool onCooldown = false;
    protected float timer = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !onCooldown)
        {
            Attack();
        }

        if(onCooldown)
        {
            HandleCooldown();
        }
    }

    protected virtual void Attack()
    {
        onCooldown = true;
    }

    protected virtual void HandleCooldown()
    {
        timer += Time.deltaTime;

        if (timer >= cooldownTime)
        {
            timer = 0;
            onCooldown = false;
        }
    }
}
