using UnityEngine;

public class TearJatadaState : IState
{

    float attackDuration = 5f;
    float timeSinceStart = 0f;
    GameObject bossGameObject;
    SpriteRenderer sp;
    TearJet tearJet;

    public TearJatadaState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        sp = bossGameObject.GetComponent<SpriteRenderer>();
        tearJet = bossGameObject.GetComponent<TearJet>();
    }
    public void Enter()
    {
        Debug.Log("Entrou em jatada!");
        sp.color = Color.green;
        tearJet.InstantiateJetTrace();
        timeSinceStart = 0f;
    }

    public void Exit()
    {
        Debug.Log("Saiu da jatada");
        sp.color = Color.white;
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
