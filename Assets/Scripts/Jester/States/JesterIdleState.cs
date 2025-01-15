using System.Collections.Generic;
using UnityEngine;

public class JesterIdleState : IState
{
    float timeSinceStart = 0f;
    float idleDuration;
    GameObject bossGameObject;
    CopasSpawner copasSpawner;
    OurosSpawner ourosSpawner;
    JesterStateManager jesterSM;

    public JesterIdleState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        ourosSpawner = bossGameObject.GetComponent<OurosSpawner>();
        copasSpawner = bossGameObject.GetComponent<CopasSpawner>();
        jesterSM = bossGameObject.GetComponent<JesterStateManager>();
        idleDuration = jesterSM.idleDuration;
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

        if(!ourosSpawner.isSpawning)
            possibleAttacks.Add(new OurosState(bossGameObject));
        
        if(!copasSpawner.isSpawning)
            possibleAttacks.Add(new CopasState(bossGameObject));

        IState attack = possibleAttacks[Random.Range(0, possibleAttacks.Count)];
        return attack;
    }

    public void OnTriggerEnter(Collider other){}
    public void OnTriggerExit(Collider other){}
    public void OnTriggerStay(Collider other){}
}
