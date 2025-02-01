using System.Collections.Generic;
using UnityEngine;

public class JesterDeathState : IState
{
    float attackDuration = 3f;
    float timeSinceStart = 0f;
    SpriteRenderer sp;
    GameObject bossGameObject;

    public JesterDeathState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        sp = bossGameObject.GetComponent<SpriteRenderer>();
    }

    public void Enter()
    {
        Debug.Log("se morrio");
        sp.color = Color.blue;
        timeSinceStart = 0f;
    }

    public void Exit()
    {
        Debug.Log("F");
        sp.color = Color.white;
        bossGameObject.SetActive(false);
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
