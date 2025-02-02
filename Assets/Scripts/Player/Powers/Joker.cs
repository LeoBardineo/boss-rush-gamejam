using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Joker : Power
{
    List<Power> powers;
    Power selectedPower;

    [SerializeField]
    GameObject chapeu;

    protected override void Initialize()
    {
        base.Initialize();
        powers = new List<Power> {
            GetComponent<Bang>(),
            GetComponent<Blaze>(),
            GetComponent<Bunny>(),
            GetComponent<Rain>(),
        };
        cooldownTime = GlobalData.skillsData["Coringa"][0];
    }

    public override void EnterPower()
    {
        StartCoroutine(EsperaEscolherCarta());
    }

    IEnumerator EsperaEscolherCarta()
    {
        chapeu.SetActive(true);
        playerController.LockMovement();
        animator.Play(animationName);

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        
        playerController.UnlockMovement();
        chapeu.SetActive(false);
        selectedPower = powers[Random.Range(0, powers.Count)];
        attackRemaining = selectedPower.attackDuration;
        lockedRemaining = selectedPower.lockedTime;
        cooldownRemaining = selectedPower.cooldownTime;
        attackArea = selectedPower.attackArea;
        selectedPower.damageModifier = damageModifier;
        if(lockedRemaining != 0f)
            playerController.LockMovement();
        selectedPower.EnterPower();
    }
    
    public override void EndPower()
    {
        selectedPower.EndPower();
        selectedPower.damageModifier = 1;
    }

}