using UnityEngine;

public class TearJatadaState : IState
{

    float attackDuration = 8.5f;
    float timeSinceStart = 0f;
    GameObject bossGameObject;
    SpriteRenderer sp;
    TearJet tearJet;

    private Animator anim;
 
    public TearJatadaState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        sp = bossGameObject.GetComponent<SpriteRenderer>();
        tearJet = bossGameObject.GetComponent<TearJet>();
        anim = bossGameObject.GetComponent<Animator>();
    }
    public void Enter()
    {
        anim.Play("ataqueChapeu");
        timeSinceStart = 0f;
        tearJet.InstantiateJetTrace();
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
