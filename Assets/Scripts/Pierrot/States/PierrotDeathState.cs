using UnityEngine;

public class PierrotDeathState : IState
{
    float attackDuration = 3f;
    float timeSinceStart = 0f;
    SpriteRenderer sp;
    GameObject bossGameObject;
    PierrotStateManager pierrotStateManager;

    public PierrotDeathState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        sp = bossGameObject.GetComponent<SpriteRenderer>();
        pierrotStateManager = bossGameObject.GetComponent<PierrotStateManager>();
    }

    public void Enter()
    {
        Debug.Log("se morrio");
        sp.color = Color.blue;
        timeSinceStart = 0f;
        pierrotStateManager.BossDeath();
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
