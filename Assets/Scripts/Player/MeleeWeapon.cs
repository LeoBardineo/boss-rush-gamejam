using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    protected GameObject attackArea = default;
    protected bool attacking = false, onCooldown = false, attackWindowClosed = false;
    protected float attackWindow = 0.25f, cooldownTime;
    protected float timer = 0f;

    [SerializeField] protected PlayerController PlayerControl;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        attackArea=transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && !onCooldown)
        {
            Attack();
            onCooldown = true;
        }

        if(attacking)
        {
            timer += Time.deltaTime;

            if (timer >= attackWindow)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
                attackWindowClosed = true;
            }
        }

        if (attackWindowClosed)
        {
            timer += Time.deltaTime;
            // Debug.Log("Tempo passado em cooldown:"+timer);
            if (timer >= cooldownTime)
            {
                timer = 0;
                attackWindowClosed = false;
                onCooldown = false;
            }
        }

            attackArea.transform.localPosition = new Vector3(1.35f,0,0);

    }

    protected void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
