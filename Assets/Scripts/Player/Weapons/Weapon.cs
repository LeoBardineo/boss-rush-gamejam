using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected float cooldownTime;

    public bool onCooldown = false;
    public float timer = 0f;

    public float damageModifier = 1f;
    public float bananaSplitModifier = 0;
    public bool bananaSplitEffect = false;
    public int bananaSplitAmountOfHits = 0;
    protected Animator animator;
    public bool attacking = false;

    void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        animator =  GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(GlobalData.attackButton) && !onCooldown)
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

    public abstract void ChangeAttackAreaModifiers();
}
