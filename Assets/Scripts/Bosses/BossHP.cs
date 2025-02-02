using System.Collections;
using UnityEngine;

public class BossHP : MonoBehaviour
{

    public float maxHP, HP;
    private float originalColorTimer;
    private bool attacked = false, invincible=false;
    [SerializeField] SpriteRenderer SpriteRenderer;
    public bool fase2 = false, firstTimeFase2 = true;
    private Color originalColor;
    //Ideia: Variavel global para trackear quantos bosses já foram derrotados pra ajustar o HP de cada paz

    [SerializeField]
    float timeOnRed = 1f;

    [SerializeField]
    PlayerController playerController;

    BossStateManager bossStateManager;
    StateManager stateManager;

    void Start()
    {
        bossStateManager = GetComponent<BossStateManager>();
        stateManager = bossStateManager.stateManager;
        HP = GlobalData.bossData["HP"][GlobalData.level];
        maxHP = HP;
    }

    void Update()
    {
        if (!attacked)
        {
            originalColor = SpriteRenderer.color;
        }
        
        if (attacked = true && originalColorTimer <= timeOnRed)
        {
            originalColorTimer += Time.deltaTime;
        }
        else
        {
            attacked = false;
            SpriteRenderer.color = originalColor;
            originalColorTimer = 0;
            invincible = false;
        }

    }


    public void Damage(float damage)
    {
        if (!invincible)
        {
            HP -= damage;
            invincible = true;
            if (!fase2 && HP <= (maxHP/2))
                fase2 = true;
            
            if(HP <= 0)
            {
                HP = 0;

                if(bossStateManager is JesterStateManager)
                {
                    JesterDeath();
                    return;
                }

                if(bossStateManager is HarlequimStateManager)
                {
                    HarlequimDeath();
                    return ;
                }

                if(bossStateManager is PierrotStateManager)
                {
                    PierrotDeath();
                    return;
                }
            }
            
            attacked = true;
            SpriteRenderer.color = new Color(1f, 0f, 0f, 1f);
        }
    }

    void JesterDeath()
    {
        invincible = true;
        
        if (stateManager.currentState is CopasState copasState)
        {
            copasState.copasSpawner.StopSpawning();
        }

        if(stateManager.currentState is OurosState ourosState)
        {
            ourosState.ourosSpawner.StopSpawning();
        }

        if(PausSpawner.cardSpawned)
        {
            PausSpawner.StopAttack(playerController);
        }

        stateManager.TransitionToState(new JesterDeathState(gameObject));
    }

    void HarlequimDeath()
    {
        stateManager.TransitionToState(new HarlequimDeathState(gameObject));

        invincible = true;
    }

    void PierrotDeath()
    {
        stateManager.TransitionToState(new PierrotDeathState(gameObject));

        invincible = true;
    }
}
