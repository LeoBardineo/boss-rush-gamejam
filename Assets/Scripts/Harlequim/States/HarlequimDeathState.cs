using UnityEngine;

public class HarlequimDeathState : IState
{
    float attackDuration = 3f;
    float timeSinceStart = 0f;
    SpriteRenderer sp;
    GameObject bossGameObject;
    HarlequimStateManager harlequimStateManager;
    public HarlequimDeathState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        sp = bossGameObject.GetComponent<SpriteRenderer>();
        harlequimStateManager = bossGameObject.GetComponent<HarlequimStateManager>();
    }

    public void Enter()
    {
        Debug.Log("se morrio");
        sp.enabled = false;
        timeSinceStart = 0f;
        harlequimStateManager.BossDeath();
    }

    public void Exit()
    {
        Debug.Log("F");
        sp.color = Color.white;
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
