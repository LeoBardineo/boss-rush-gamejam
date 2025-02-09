using UnityEngine;

public class ShootingMasksState : IState
{
    float attackDuration = 7f;
    float timeSinceStart = 0f;
    GameObject bossGameObject;

    HomingMasks homingMasks;
    public ShootingMasksState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        homingMasks = bossGameObject.GetComponent<HomingMasks>();

    }

    public void Enter()
    {
        Debug.Log("Entrou em ShootingMasks");
        timeSinceStart =0f;
        homingMasks.BeginHomingMasksAttack();
        GlobalData.playerCanTakeDamage=false;
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
