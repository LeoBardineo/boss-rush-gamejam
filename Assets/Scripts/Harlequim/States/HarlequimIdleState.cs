using System.Collections.Generic;
using UnityEngine;

public class HarlequimIdleState : IState
{
    float timeSinceStart = 0f;
    float idleDuration;
    GameObject bossGameObject;
    HarlequimStateManager harlequimSM;

    //ShootingMasksAttack
    //ClappingAttack
    //SkateHandAttack
    //CrushAttack
    
    public HarlequimIdleState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        harlequimSM = bossGameObject.GetComponent<HarlequimStateManager>();
        idleDuration = harlequimSM.idleDuration;
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
    }

    public IState GetNext()
    {
        // continua em idle até terminar a sua duração
        if(timeSinceStart < idleDuration) return this;

        // se muito perto, dar chute pra longe
        // se muito longe, corda invisivel
        // se não, aleatorio entre outros ataques

        List<IState> possibleAttacks = new List<IState>{
            new EspadasState(bossGameObject),
        };

        if(!PausSpawner.cardSpawned)
            possibleAttacks.Add(new PausState(bossGameObject));

        IState attack = possibleAttacks[Random.Range(0, possibleAttacks.Count)];
        return attack;
    }

    public void OnTriggerEnter(Collider other){}
    public void OnTriggerExit(Collider other){}
    public void OnTriggerStay(Collider other){}
}
