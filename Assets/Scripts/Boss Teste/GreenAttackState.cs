using System.Collections.Generic;
using UnityEngine;

public class GreenAttackState : IState
{
    float attackDuration = 2f;
    float timeSinceStart = 0f;
    GameObject bossGameObject;
    SpriteRenderer sp;

    public GreenAttackState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        sp = bossGameObject.GetComponent<SpriteRenderer>();
    }

    public void Enter()
    {
        // inicia alguma animação do ataque começando
        Debug.Log("Entrou em estado de ataque verde!");
        sp.color = Color.green;
        timeSinceStart = 0f;
    }

    public void Exit()
    {
        // inicia alguma animação do ataque terminando
        Debug.Log("Saiu do estado de ataque verde!");
        sp.color = Color.white;
    }

    public void Update()
    {
        timeSinceStart += Time.deltaTime;
    }

    public IState GetNext()
    {
        if(timeSinceStart < attackDuration) return this;

        return new IdleState(bossGameObject);
    }
    
    public void OnTriggerEnter(Collider other){}
    public void OnTriggerExit(Collider other){}
    public void OnTriggerStay(Collider other){}
}
