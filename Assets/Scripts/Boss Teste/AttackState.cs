using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    float attackDuration = 5f;
    float timeSinceStart = 0f;
    IdleState idleState = new IdleState();

    public void Enter()
    {
        // inicia alguma animação do ataque começando
        Debug.Log("Entrou em estado de ataque!");
        timeSinceStart = 0f;
    }

    public void Exit()
    {
        // inicia alguma animação do ataque terminando
        Debug.Log("Saiu do estado de ataque!");
    }

    public void Update()
    {
        timeSinceStart += Time.deltaTime;
    }

    public IState GetNext()
    {
        if(timeSinceStart < attackDuration) return this;

        return idleState;
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
