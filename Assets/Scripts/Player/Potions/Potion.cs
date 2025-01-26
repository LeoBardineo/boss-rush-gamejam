using UnityEngine;

abstract class Potion : MonoBehaviour {
    public PlayerController playerController;
    public float buffDuration, cooldownTime, lockedTime;
    public float cooldownRemaining = 0f, lockedRemaining = 0f, buffRemaining = 0f;
    bool isUsingPotion = false;

    void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if(buffRemaining > 0f)
        {
            buffRemaining -= Time.deltaTime;
            if (buffRemaining <= 0f){
                buffRemaining = 0f;
            }
        } else if(isUsingPotion) {
            DisablePotion();
        }

        if(lockedRemaining > 0f)
        {
            lockedRemaining -= Time.deltaTime;
            if (lockedRemaining <= 0f){
                playerController.UnlockMovement();
                lockedRemaining = 0f;
            }
            if(isUsingPotion) return;
        }

        if(cooldownRemaining > 0f)
        {
            cooldownRemaining -= Time.deltaTime;
            if (cooldownRemaining < 0f) cooldownRemaining = 0f;
            return;
        }

        if(!playerController.isGrounded) return;

        if(playerController.potionInCooldown)
            playerController.potionInCooldown = false;
    }

    public void UsePotion()
    {
        buffRemaining = buffDuration;
        cooldownRemaining = cooldownTime;
        lockedRemaining = lockedTime;
        isUsingPotion = true;
        if(lockedTime != 0f)
            playerController.LockMovement();
        EnterPotion();
        playerController.potionInCooldown = true;
    }

    void DisablePotion()
    {
        isUsingPotion = false;
        EndPotion();
    }

    public abstract void EnterPotion();
    public abstract void EndPotion();
}