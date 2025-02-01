using System.Collections.Generic;
using UnityEngine;

public class OurosState : IState
{
    float attackDuration;
    float timeSinceStart = 0f;
    GameObject bossGameObject;
    SpriteRenderer sp;
    public OurosSpawner ourosSpawner;
    BossHP bossHP;

    public OurosState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        sp = bossGameObject.GetComponent<SpriteRenderer>();
        ourosSpawner = bossGameObject.GetComponent<OurosSpawner>();
        bossHP = bossGameObject.GetComponent<BossHP>();
        attackDuration = ourosSpawner.attackDuration;
        if(bossHP.fase2)
            attackDuration = ourosSpawner.secondPhaseWaitDuration;
    }

    public void Enter()
    {
        // inicia alguma animação do ataque começando
        Debug.Log("Entrou em ouros!");
        sp.color = Color.yellow;
        ourosSpawner.StartSpawning();
        timeSinceStart = 0f;
    }

    public void Exit()
    {
        // inicia alguma animação do ataque terminando
        Debug.Log("Saiu do ouros!");
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
