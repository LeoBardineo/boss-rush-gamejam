using UnityEngine;

public class ShootingMasksState : IState
{
    float attackDuration = 5f;
    float timeSinceStart = 0f;
    GameObject bossGameObject;
    SpriteRenderer sp;

    HomingMasks homingMasks;
    public ShootingMasksState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        sp = bossGameObject.GetComponent<SpriteRenderer>();
        homingMasks = bossGameObject.GetComponent<HomingMasks>();

    }

    public void Enter()
    {
        Debug.Log("Entrou em ShootingMasks");
        timeSinceStart =0f;
        homingMasks.BeginHomingMasksAttack();
    }

    public void Exit()
    {
        Debug.Log("Saiu do ShootingMasks");
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
