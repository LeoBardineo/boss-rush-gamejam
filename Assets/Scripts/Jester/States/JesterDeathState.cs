using System.Collections.Generic;
using UnityEngine;

public class JesterDeathState : IState
{
    float attackDuration = 3f;
    float timeSinceStart = 0f;
    SpriteRenderer sp;
    GameObject bossGameObject;
    JesterStateManager jesterStateManager;

    public JesterDeathState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        sp = bossGameObject.GetComponent<SpriteRenderer>();
        jesterStateManager = bossGameObject.GetComponent<JesterStateManager>();
    }

    public void Enter()
    {
        Debug.Log("se morrio");
        sp.enabled = false;
        timeSinceStart = 0f;
        jesterStateManager.BossDeath();
    }

    public void Exit()
    {
        Debug.Log("F");
    }

    public void Update()
    {
        timeSinceStart += Time.deltaTime;
    }

    public IState GetNext()
    {
        if(timeSinceStart < attackDuration) return this;

        return null;
    }
    
    public void OnTriggerEnter(Collider other){}
    public void OnTriggerExit(Collider other){}
    public void OnTriggerStay(Collider other){}
}
