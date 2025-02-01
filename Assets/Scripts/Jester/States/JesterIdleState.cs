using System.Collections.Generic;
using UnityEngine;

public class JesterIdleState : IState
{
    float timeSinceStart = 0f;
    float idleDuration;
    GameObject bossGameObject;
    
    Animator animator;
    PlataformaSpawner plataformaSpawner;
    EspadasSpawner espadasSpawner;
    PausSpawner pausSpawner;
    CopasSpawner copasSpawner;
    OurosSpawner ourosSpawner;
    BossHP bossHP;
    JesterStateManager jesterSM;

    public JesterIdleState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        animator = bossGameObject.GetComponent<Animator>();
        plataformaSpawner = bossGameObject.GetComponent<PlataformaSpawner>();
        espadasSpawner = bossGameObject.GetComponent<EspadasSpawner>();
        pausSpawner = bossGameObject.GetComponent<PausSpawner>();
        ourosSpawner = bossGameObject.GetComponent<OurosSpawner>();
        copasSpawner = bossGameObject.GetComponent<CopasSpawner>();
        jesterSM = bossGameObject.GetComponent<JesterStateManager>();
        bossHP = bossGameObject.GetComponent<BossHP>();
        idleDuration = jesterSM.idleDuration;
    }

    public void Enter()
    {
        Debug.Log("Entrou em Idle");
        animator.Play("JesterIdle");
        timeSinceStart = 0f;
    }

    public void Exit()
    {
        // Debug.Log("Saiu de Idle");
    }

    public void Update()
    {
        timeSinceStart += Time.deltaTime;
    }

    public IState GetNext()
    {
        // continua em idle até terminar a sua duração
        if(timeSinceStart < idleDuration) return this;

        // se muito perto, dar chute pra longe
        // se muito longe, corda invisivel
        // se não, aleatorio entre outros ataques

        if(PlayerHP.dead)
            return new JesterIdleState(bossGameObject);

        List<IState> possibleAttacks = new List<IState>();

        if(plataformaSpawner.enabled && !PausSpawner.cardSpawned)
            possibleAttacks.Add(new PlataformaState(bossGameObject));

        if(espadasSpawner.enabled)
            possibleAttacks.Add(new EspadasState(bossGameObject));

        if(pausSpawner.enabled && !PausSpawner.cardSpawned)
            possibleAttacks.Add(new PausState(bossGameObject));

        if(ourosSpawner.enabled && !ourosSpawner.isSpawning && (!bossHP.fase2 || ourosSpawner.attackCooldownRemaining <= 0))
            possibleAttacks.Add(new OurosState(bossGameObject));
        
        if(copasSpawner.enabled && !copasSpawner.isSpawning)
            possibleAttacks.Add(new CopasState(bossGameObject));
        
        if(jesterSM.lastUsedAttack != null)
        {
            possibleAttacks.RemoveAll(pAttack => jesterSM.lastUsedAttack.GetType() == pAttack.GetType());
        }

        if(possibleAttacks.Count == 0)
            return new JesterIdleState(bossGameObject);

        IState attack = possibleAttacks[Random.Range(0, possibleAttacks.Count)];
        jesterSM.lastUsedAttack = attack;
        animator.Play("JesterAttack");
        return attack;
    }

    public void OnTriggerEnter(Collider other){}
    public void OnTriggerExit(Collider other){}
    public void OnTriggerStay(Collider other){}
}
