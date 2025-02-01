using UnityEngine;

public class BallHandState : IState
{

    float attackDuration = 5f;
    float timeSinceStart = 0f;
    GameObject bossGameObject;
    SpriteRenderer sp;

    BallHandAttack ballHandAttack;
    public BallHandState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        sp = bossGameObject.GetComponent<SpriteRenderer>();
        ballHandAttack = bossGameObject.GetComponent<BallHandAttack>();
    }

    public void Enter()
    {
        Debug.Log("Entrou em BallHand");
        ballHandAttack.StartVanish();
        timeSinceStart =0f;
    }

    public void Exit()
    {
        Debug.Log("Saiu do BallHand");
    }
    // Update is called once per frame
    public void Update()
    {
        timeSinceStart += Time.deltaTime;
    }

    public IState GetNext()
    {
        if (timeSinceStart < attackDuration) return this;

        return new HarlequimIdleState(bossGameObject);
    }
    public void OnTriggerEnter(Collider other)
    {}
    public void OnTriggerExit(Collider other)
    {}
    public void OnTriggerStay(Collider other)
    {}
}
