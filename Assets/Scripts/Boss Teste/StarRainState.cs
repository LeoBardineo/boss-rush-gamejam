using System.Collections.Generic;
using UnityEngine;

public class StarRainState : IState
{
    GameObject bossGameObject;
    SpriteRenderer sp;
    StarSpawner starSpawner;
    float timeSinceStart = 0f;

    public StarRainState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        sp = bossGameObject.GetComponent<SpriteRenderer>();
        starSpawner = bossGameObject.GetComponent<StarSpawner>();
    }

    public void Enter()
    {
        Debug.Log("Preparando Star Rain!");
        sp.color = Color.red;
        starSpawner.StartSpawning();
        timeSinceStart = 0f;
    }

    public void Exit()
    {
        Debug.Log("Terminou de preparar Star Rain!");
        starSpawner.EndSpawning();
        sp.color = Color.white;
    }

    public void Update()
    {
        timeSinceStart += Time.deltaTime;
    }

    public IState GetNext()
    {
        if(timeSinceStart < starSpawner.antecipationDuration) return this;

        return new IdleState(bossGameObject);
    }

    public void OnTriggerEnter(Collider other){}
    public void OnTriggerExit(Collider other){}
    public void OnTriggerStay(Collider other){}
}
