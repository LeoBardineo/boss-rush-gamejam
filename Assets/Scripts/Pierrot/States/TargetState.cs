using UnityEngine;

public class TargetState : IState
{
    float attackDuration=5f;
    float timeSinceStart = 0f;
    GameObject bossGameObject;
    SpriteRenderer sp;
    TearJet tearJet;

    public TargetState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        sp = bossGameObject.GetComponent<SpriteRenderer>();
        tearJet = bossGameObject.GetComponent<TearJet>();
    }
    public void Enter()
    {
        Debug.Log("Entrou na jatada");
        sp.color = Color.cyan;
        tearJet.InstantiateJetTrace();
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
        if (timeSinceStart < attackDuration) return this;

        return new PierrotIdleState(bossGameObject); 
    }

    public void OnTriggerEnter(Collider other)
    {
    }

    public void OnTriggerExit(Collider other)
    {
    }

    public void OnTriggerStay(Collider other)
    {
    }



    // Update is called once per frame
}
