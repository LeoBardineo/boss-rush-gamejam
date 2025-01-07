using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    float timeSinceStart = 0f;
    float idleDuration = 1f;
    StarSpawner starSpawner;
    GameObject bossGameObject;

    public IdleState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        starSpawner = bossGameObject.GetComponent<StarSpawner>();
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

        List<IState> possibleAttacks = new List<IState>
        {
            new AttackState(bossGameObject)
        };

        if(!starSpawner.isSpawning)
            possibleAttacks.Add(new StarRainState(bossGameObject));

        IState attack = possibleAttacks[Random.Range(0, possibleAttacks.Count)];
        return attack;
    }

    public void OnTriggerEnter(Collider other){}
    public void OnTriggerExit(Collider other){}
    public void OnTriggerStay(Collider other){}
}
