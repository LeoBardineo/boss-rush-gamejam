using System.Collections.Generic;
using UnityEngine;

public class CopasState : IState
{
    float attackDuration;
    float timeSinceStart = 0f;
    GameObject bossGameObject;
    SpriteRenderer sp;
    CopasSpawner copasSpawner;
    BossHP bossHP;

    public CopasState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        sp = bossGameObject.GetComponent<SpriteRenderer>();
        copasSpawner = bossGameObject.GetComponent<CopasSpawner>();
        bossHP = bossGameObject.GetComponent<BossHP>();
        attackDuration = copasSpawner.attackDuration;
        if(bossHP.fase2)
            attackDuration = copasSpawner.secondPhaseWaitDuration;
    }

    public void Enter()
    {
        // inicia alguma animação do ataque começando
        Debug.Log("Entrou em copas!");
        sp.color = Color.red;
        copasSpawner.StartSpawning();
        timeSinceStart = 0f;
    }

    public void Exit()
    {
        // inicia alguma animação do ataque terminando
        Debug.Log("Saiu do copas!");
        sp.color = Color.white;
    }

    public void Update()
    {
        timeSinceStart += Time.deltaTime;
    }

    public IState GetNext()
    {
        if(timeSinceStart < attackDuration) return this;

        return new JesterIdleState(bossGameObject);
    }
    
    public void OnTriggerEnter(Collider other){}
    public void OnTriggerExit(Collider other){}
    public void OnTriggerStay(Collider other){}
}
