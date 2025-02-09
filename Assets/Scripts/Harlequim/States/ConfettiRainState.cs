using UnityEngine;

public class ConfettiRainState : IState
{
    float attackDuration = 5f;
    float timeSinceStart = 0f;
    GameObject bossGameObject;
    ConfettiRainAttack confettiRainAttack;
    public ConfettiRainState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        confettiRainAttack = bossGameObject.GetComponent<ConfettiRainAttack>();

    }

    public void Enter()
    {
        Debug.Log("Entrou em ConfettiRain");
        timeSinceStart =0f;
        confettiRainAttack.BeginAttack();
    }

    public void Exit()
    {
        Debug.Log("Saiu do ConfettiRain");
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
