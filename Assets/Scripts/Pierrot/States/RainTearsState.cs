using UnityEngine;

public class RainTearsState : IState
{
    float attackDuration;
    float timeSinceStart = 0f;
    GameObject bossGameObject;
    SpriteRenderer sp;
    SpawnRainTears spawnRainTears;
 
    private Animator anim;

    public RainTearsState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        sp = bossGameObject.GetComponent<SpriteRenderer>();
        spawnRainTears = bossGameObject.GetComponent<SpawnRainTears>();
        attackDuration = spawnRainTears.attackDuration;
        anim = bossGameObject.GetComponent<Animator>();
    }

    public void Enter()
    {
        anim.Play("ataqueChuva");
        spawnRainTears.StartSpawning();
        timeSinceStart = 0f;
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
        if(timeSinceStart < attackDuration) return this;

        return new PierrotIdleState(bossGameObject);
    }
    
    public void OnTriggerEnter(Collider other){}
    public void OnTriggerExit(Collider other){}
    public void OnTriggerStay(Collider other){}
}
