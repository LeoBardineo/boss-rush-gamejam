using UnityEngine;

public class ClappingState : IState
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float attackDuration = 5f;
    float timeSinceStart = 0f;
    GameObject bossGameObject;

    ClappingAttack clappingAttack;
    public ClappingState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        clappingAttack = bossGameObject.GetComponent<ClappingAttack>();

    }

    public void Enter()
    {
        Debug.Log("Entrou em ClapAttack");
        timeSinceStart =0f;
        clappingAttack.BeginClapAttack();
    }

    public void Exit()
    {
        Debug.Log("Saiu do ClapAttack");
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
