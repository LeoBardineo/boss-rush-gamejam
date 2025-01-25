using UnityEngine;

abstract class Power : MonoBehaviour {
    public float cooldownTime, lockedTime;
    public int damage;
    protected PlayerController playerController;
    float cooldownRemaining = 0f, lockedRemaining = 0f;
    bool isUsingPower = false;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if(lockedRemaining > 0f) {
            lockedRemaining -= Time.deltaTime;
            if (lockedRemaining <= 0f)
                playerController.UnlockMovement();
        }

        if(cooldownRemaining > 0f) {
            cooldownRemaining -= Time.deltaTime;
            if (cooldownRemaining < 0f) cooldownRemaining = 0f;
            return;
        } else if(isUsingPower) {
            DisablePower();
        }

        if(!playerController.isGrounded) return;

        if(Input.GetKeyDown(KeyCode.F))
        {
            UsePower();
        }
    }

    void UsePower()
    {
        cooldownRemaining = cooldownTime;
        lockedRemaining = lockedTime;
        isUsingPower = true;
        if(lockedTime != 0f)
            playerController.LockMovement();
        EnterPower();
    }

    void DisablePower()
    {
        isUsingPower = false;
        EndPower();
    }

    protected abstract void EnterPower();
    protected abstract void EndPower();
}