using UnityEngine;

public abstract class Power : MonoBehaviour {
    public float attackDuration, cooldownTime, lockedTime, damageModifier;
    public int damage;
    public PlayerController playerController;
    public float cooldownRemaining = 0f, lockedRemaining = 0f, attackRemaining;
    public AttackArea attackArea;
    public bool isUsingPower = false;

    protected Animator animator;
    protected AudioSource audioSource;

    [SerializeField]
    protected string animationName;
    
    [SerializeField]
    AudioClip powerSound;

    public void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        // cooldownTime = GlobalData.playerData["PowerCD"][GlobalData.level];
    }

    void Update()
    {
        if(attackRemaining > 0f)
        {
            attackRemaining -= Time.deltaTime;
            if (attackRemaining <= 0f){
                attackRemaining = 0f;
            }
        } else if(isUsingPower) {
            DisablePower();
        }

        if(lockedRemaining > 0f)
        {
            lockedRemaining -= Time.deltaTime;
            if (lockedRemaining <= 0f){
                playerController.UnlockMovement();
                lockedRemaining = 0f;
            }
            if(isUsingPower) return;
        }

        if(cooldownRemaining > 0f)
        {
            cooldownRemaining -= Time.deltaTime;
            if (cooldownRemaining < 0f) cooldownRemaining = 0f;
            return;
        }

        if(!playerController.isGrounded) return;

        if(playerController.powerInCooldown)
            playerController.powerInCooldown = false;
    }

    public void UsePower()
    {
        attackRemaining = attackDuration;
        cooldownRemaining = cooldownTime;
        lockedRemaining = lockedTime;
        isUsingPower = true;
        if(lockedTime != 0f)
            playerController.LockMovement();
        EnterPower();
        playerController.powerInCooldown = true;
        audioSource.PlayOneShot(powerSound);
    }

    void DisablePower()
    {
        isUsingPower = false;
        EndPower();
    }

    public abstract void EnterPower();
    public abstract void EndPower();
}