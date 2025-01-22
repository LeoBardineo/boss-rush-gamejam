using UnityEngine;

class Blaze : MonoBehaviour {

    public GameObject powerArea;
    public float cooldownTime;
    public int damage;
    float cooldownRemaining = 0f;
    bool isUsingPower = false;
    PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if(cooldownRemaining > 0f) {
            cooldownRemaining -= Time.deltaTime;
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
        powerArea.SetActive(true);
    }

    void DisablePower()
    {
        isUsingPower = false;
        playerController.UnlockMovement();
        powerArea.SetActive(false);
    }

}