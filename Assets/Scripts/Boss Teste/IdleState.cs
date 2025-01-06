using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    float timeSinceStart = 0f;
    float idleDuration = 2f;
    List<IState> attacks;

    public void Enter()
    {
        attacks = new List<IState> {
            new AttackState()
        };
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
        IState attack = attacks[Random.Range(0, attacks.Count)];
        return attack;
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }

    public void OnTriggerExit(Collider other)
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        
    }
}
