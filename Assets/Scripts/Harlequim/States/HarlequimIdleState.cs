using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HarlequimIdleState : IState
{
    float timeSinceStart = 0f;
    float idleDuration=2f;
    GameObject bossGameObject,playerGO;
    HarlequimStateManager harlequimSM;
    

    BossHP bossHP;
    BallHandAttack ballHandAttack;
    ClappingAttack clappingAttack;
    ConfettiRainAttack confettiRainAttack;
    HomingMasksBehaviour homingMasks;
    Animator animator;
    TransitionHarlequin transitionHarlequin;
    
    public HarlequimIdleState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        // animator = bossGameObject.GetComponent<Animator>();
        ballHandAttack = bossGameObject.GetComponent<BallHandAttack>();
        clappingAttack = bossGameObject.GetComponent<ClappingAttack>();
        confettiRainAttack = bossGameObject.GetComponent<ConfettiRainAttack>();
        homingMasks = bossGameObject.GetComponent<HomingMasksBehaviour>();
        harlequimSM = bossGameObject.GetComponent<HarlequimStateManager>();
        bossHP = bossGameObject.GetComponent<BossHP>();
        transitionHarlequin = bossGameObject.GetComponent<TransitionHarlequin>();
        idleDuration = harlequimSM.idleDuration;

    }

    public void Enter()
    {
        GlobalData.playerCanTakeDamage=false;
        Debug.Log("Entrou em Idle");
        // animator.Play("HarlequinIdle");
        timeSinceStart = 0f;

    }

    public void Exit()
    {
        Debug.Log("Saiu de Idle");
        GlobalData.playerCanTakeDamage=true;
    }

    public void Update()
    {
        timeSinceStart += Time.deltaTime;
    }

    public IState GetNext()
    {
        if(timeSinceStart < idleDuration) return this;

        if(PlayerHP.dead)
        {
            return new JesterIdleState(bossGameObject);
        }
        List<IState> possibleAttacks = new List<IState>();

        if(!BallHandAttack.ballHandAttacking)
            possibleAttacks.Add(new BallHandState(bossGameObject));
        if(!ClappingAttack.clapping)
            possibleAttacks.Add(new ClappingState(bossGameObject));
        if(!ConfettiRainAttack.isAttacking)
            possibleAttacks.Add(new ConfettiRainState(bossGameObject));
        if (!HomingMasks.homingMasksAttacking)
            possibleAttacks.Add(new ShootingMasksState(bossGameObject));
        if(bossHP.fase2)
        {
            if(bossHP.firstTimeFase2)
            {
                transitionHarlequin.Transition();
                bossHP.firstTimeFase2 = false;
            }
        }

        IState attack = possibleAttacks[Random.Range(0, possibleAttacks.Count)];
        return attack;
    }

    public void OnTriggerEnter(Collider other){}
    public void OnTriggerExit(Collider other){}
    public void OnTriggerStay(Collider other){}
}
