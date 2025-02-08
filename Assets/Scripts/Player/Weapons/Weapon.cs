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
    protected AudioSource audioSource;
    public bool attacking = false;

    [SerializeField]
    AudioClip weaponSound;

    void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        animator =  GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(onCooldown)
        {
            HandleCooldown();
        }

        if (Input.GetKeyDown(GlobalData.attackButton) && !onCooldown)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        audioSource.PlayOneShot(weaponSound);
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
    public abstract bool RetornaBananaSplitAtivo();
}
