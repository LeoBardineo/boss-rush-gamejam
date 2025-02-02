using UnityEngine;

public class Fase2State : IState
{
    GameObject bossGameObject;
    private Animator anim;

    float attackDuration = 6f;
    float timeSinceStart = 0f;

    public Fase2State(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        // sp = bossGameObject.GetComponent<SpriteRenderer>();
        // rageScream = bossGameObject.GetComponent<RageScream>();
        anim = bossGameObject.GetComponent<Animator>();
    }
    public void Enter()
    {
        timeSinceStart = 0f;
        anim.Play("ataqueInundaçao");
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
