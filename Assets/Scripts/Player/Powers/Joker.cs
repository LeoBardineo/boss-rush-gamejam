using System.Collections.Generic;
using UnityEngine;

class Joker : Power
{
    List<Power> powers;
    Power selectedPower;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        powers = new List<Power> {
            GetComponent<Bang>(),
            GetComponent<Blaze>(),
            GetComponent<Bunny>(),
            GetComponent<Rain>(),
        };
    }

    public override void EnterPower()
    {
        selectedPower = powers[Random.Range(0, powers.Count)];
        attackRemaining = selectedPower.attackDuration;
        lockedRemaining = selectedPower.lockedTime;
        cooldownRemaining = selectedPower.cooldownTime;
        if(lockedRemaining != 0f)
            playerController.LockMovement();
        selectedPower.EnterPower();
    }
    
    public override void EndPower()
    {
        selectedPower.EndPower();
    }

}