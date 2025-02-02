using UnityEngine;
using UnityEditor.UI;

public class WaveState : IState
{

    float attackDuration =1.2f;
    float timeSinceStart= 0f;
    GameObject bossGameObject;
    SpriteRenderer sp;
    WaveBehaviour wave;
    
    private Animator anim;

    public WaveState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        sp = bossGameObject.GetComponent<SpriteRenderer>();
        wave = bossGameObject.GetComponent<WaveBehaviour>();
        anim = bossGameObject.GetComponent<Animator>();
    }
    public void Enter()
    {
        anim.Play("ataqueOnda");
        wave.InstantiateWave();
        timeSinceStart= 0f;
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
        if (timeSinceStart < attackDuration) return this;

        return new PierrotIdleState(bossGameObject);
    }

    public void OnTriggerEnter(Collider other)
    {}

    public void OnTriggerExit(Collider other)
    {}

    public void OnTriggerStay(Collider other)
    {}
}
