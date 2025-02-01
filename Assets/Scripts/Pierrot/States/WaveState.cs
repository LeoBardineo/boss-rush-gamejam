using UnityEngine;
using UnityEditor.UI;

public class WaveState : IState
{

    float attackDuration =1.2f;
    float timeSinceStart= 0f;
    GameObject bossGameObject;
    SpriteRenderer sp;
    WaveBehaviour wave;

    public WaveState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        sp = bossGameObject.GetComponent<SpriteRenderer>();
        wave = bossGameObject.GetComponent<WaveBehaviour>();
    }
    public void Enter()
    {
        // inicia alguma animação do ataque começando
        Debug.Log("Entrou em waves");
        wave.InstantiateWave();
        sp.color = Color.blue;
        timeSinceStart= 0f;
    }

    public void Exit()
    {
        Debug.Log("Saiu de waves");
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
    {}

    public void OnTriggerExit(Collider other)
    {}

    public void OnTriggerStay(Collider other)
    {}
}
