using System.Collections.Generic;
using UnityEngine;

public class PausState : IState
{
    float attackDuration = 1f;
    float timeSinceStart = 0f;
    GameObject bossGameObject;
    SpriteRenderer sp;
    public PausSpawner pausSpawner;

    public PausState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        sp = bossGameObject.GetComponent<SpriteRenderer>();
        pausSpawner = bossGameObject.GetComponent<PausSpawner>();
        pausSpawner.bossHP = bossGameObject.GetComponent<BossHP>();
    }

    public void Enter()
    {
        Debug.Log("Entrou em paus!");
        sp.color = Color.cyan;
        pausSpawner.SpawnCard();
        timeSinceStart = 0f;
    }

    public void Exit()
    {
        // Debug.Log("Saiu do paus!");
        pausSpawner.StartReverse();
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
