using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PierrotIdleState : IState
{
    float timeSinceStart = 0f;
    float idleDuration;
    GameObject bossGameObject;
    TearJet tearJet;
    PierrotStateManager pierrotSM;
    WaveBehaviour waveBehaviour;
    RageScream rageScream;
    BossHP bossHP;

    TransitionPierrot transitionPierrot;
    
    SpawnRainTears spawnRainTears;
    public PierrotIdleState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        tearJet = bossGameObject.GetComponent<TearJet>();
        pierrotSM = bossGameObject.GetComponent<PierrotStateManager>();
        waveBehaviour = bossGameObject.GetComponent<WaveBehaviour>();
        rageScream = bossGameObject.GetComponent<RageScream>();
        spawnRainTears = bossGameObject.GetComponent<SpawnRainTears>();
        bossHP = bossGameObject.GetComponent<BossHP>();
        transitionPierrot = bossGameObject.GetComponent<TransitionPierrot>();
        idleDuration = pierrotSM.idleDuration;
    }

    public void Enter()
    {
        Debug.Log("Entrou em Idle");
        timeSinceStart = 0f;
    }

    public void Exit()
    {
        Debug.Log("Saiu de Idle");
    }

    public void Update()
    {
        timeSinceStart += Time.deltaTime;

        if (bossHP.HP <=0 )
        {
            Debug.Log("Boss morreu, pare de bater nele tadinho!");
        }
    }

    public IState GetNext()
    {
        // continua em idle até terminar a sua duração
        if(timeSinceStart < idleDuration) return this;
        
        if(PlayerHP.dead)
            return new PierrotIdleState(bossGameObject);
            
        List<IState> possibleAttacks = new List<IState>{};
        
        if(!TearJet.jetSpawned)
            possibleAttacks.Add(new TearJatadaState(bossGameObject));
        if(!bossHP.fase2)
        {
         if(!WaveBehaviour.waveSpawned)
             possibleAttacks.Add(new WaveState   (bossGameObject));
        }
         if(!spawnRainTears.isSpawning)
             possibleAttacks.Add(new RainTearsState(bossGameObject));  
            
        if(bossHP.fase2)
        { 
            if (bossHP.firstTimeFase2)
            {
                transitionPierrot.transition();
                bossHP.firstTimeFase2 = false;
            }
            if(!RageScream.rageScreamingOn)
            possibleAttacks.Add(new RageScreamState(bossGameObject));
        }

        if(pierrotSM.lastUsedAttack != null)
        {
            possibleAttacks.RemoveAll(pAttack => pierrotSM.lastUsedAttack.GetType() == pAttack.GetType());
        }

        if (possibleAttacks.Count == 0)
            return new PierrotIdleState(bossGameObject);
        
        IState attack = possibleAttacks[Random.Range(0, possibleAttacks.Count)];
        pierrotSM.lastUsedAttack = attack;
        //animator.Play("JesterAttack");
        return attack;
    }

    public void OnTriggerEnter(Collider other){}
    public void OnTriggerExit(Collider other){}
    public void OnTriggerStay(Collider other){}
}
