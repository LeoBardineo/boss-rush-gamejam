using UnityEngine;

abstract class Power : MonoBehaviour {
    public float cooldownTime;
    public int damage;
    protected PlayerController playerController;
    float cooldownRemaining = 0f;
    bool isUsingPower = false;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
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
        isUsingPower = true;
        playerController.LockMovement();
        EnterPower();
    }

    void DisablePower()
    {
        isUsingPower = false;
        playerController.UnlockMovement();
        EndPower();
    }

    protected abstract void EnterPower();
    protected abstract void EndPower();
}