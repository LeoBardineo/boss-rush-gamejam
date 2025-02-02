using UnityEngine;

public class RageScreamState : IState
{
    float attackDuration = 4.2f;
    float timeSinceStart = 0f;
    GameObject bossGameObject;
    SpriteRenderer sp;
    RageScream rageScream;

    private Animator anim;

    public RageScreamState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        sp = bossGameObject.GetComponent<SpriteRenderer>();
        rageScream = bossGameObject.GetComponent<RageScream>();
        anim = bossGameObject.GetComponent<Animator>();
    }
    public void Enter()
    {
        timeSinceStart = 0f;
        rageScream.RageScreamOn();
        anim.Play("ataque_O_Urro");
    }

    public void Exit()
    {
        anim.Play("idle");
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
