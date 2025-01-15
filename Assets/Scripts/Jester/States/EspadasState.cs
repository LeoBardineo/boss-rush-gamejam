using System.Collections.Generic;
using UnityEngine;

public class EspadasState : IState
{
    float attackDuration = 1f;
    float timeSinceStart = 0f;
    GameObject bossGameObject;
    SpriteRenderer sp;
    EspadasSpawner espadasSpawner;

    public EspadasState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        sp = bossGameObject.GetComponent<SpriteRenderer>();
        espadasSpawner = bossGameObject.GetComponent<EspadasSpawner>();
    }

    public void Enter()
    {
        // inicia alguma animação do ataque começando
        Debug.Log("Entrou em espadas!");
        sp.color = Color.blue;
        espadasSpawner.SpawnEspadas();
        timeSinceStart = 0f;
    }

    public void Exit()
    {
        // inicia alguma animação do ataque terminando
        Debug.Log("Saiu do espadas!");
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
