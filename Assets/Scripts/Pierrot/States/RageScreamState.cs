using UnityEngine;

public class RageScreamState : IState
{
    float attackDuration = 4.2f;
    float timeSinceStart = 0f;
    GameObject bossGameObject;
    SpriteRenderer sp;
    RageScream rageScream;

    public RageScreamState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        sp = bossGameObject.GetComponent<SpriteRenderer>();
        rageScream = bossGameObject.GetComponent<RageScream>();
    }
    public void Enter()
    {
        Debug.Log("Entrou no grito");
        sp.color = Color.red;
        timeSinceStart = 0f;
        rageScream.RageScreamOn();
    }

    public void Exit()
    {
        Debug.Log("Saiu do grito");
        sp.color = Color.white;
    }

    public void Update()
    {
        timeSinceStart += Time.deltaTime;
    }
    public IState GetNext()
    {
        if(timeSinceStart < attackDuration)
        return this;

        return new PierrotIdleState(bossGameObject);
    }
    public void OnTriggerEnter(Collider other)
    {}
    public void OnTriggerExit(Collider other)
    {}
    public void OnTriggerStay(Collider other)
    {}
}
