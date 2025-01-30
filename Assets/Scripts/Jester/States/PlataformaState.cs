using System.Collections.Generic;
using UnityEngine;

public class PlataformaState : IState
{
    float attackDuration = 1f;
    float timeSinceStart = 0f;
    GameObject bossGameObject;
    PlataformaSpawner plataformaSpawner;

    int posEscolhida;

    public PlataformaState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        plataformaSpawner = bossGameObject.GetComponent<PlataformaSpawner>();
    }

    public void Enter()
    {
        Debug.Log("Entrou em plataforma!");
        timeSinceStart = 0f;
        int posAtual = plataformaSpawner.posAtual;

        posEscolhida = Random.Range(0, 3);
        if(posEscolhida == posAtual)
            posEscolhida = (posEscolhida + 1) % 3;

        plataformaSpawner.Spawnar(posEscolhida);
    }

    public void Exit()
    {
        Debug.Log("Saiu do plataforma!");
    }

    public void Update()
    {
        timeSinceStart += Time.deltaTime;
    }

    public IState GetNext()
    {
        if(timeSinceStart < attackDuration) return this;

        return new JesterIdleState(bossGameObject);
    }
    
    public void OnTriggerEnter(Collider other){}
    public void OnTriggerExit(Collider other){}
    public void OnTriggerStay(Collider other){}
}
