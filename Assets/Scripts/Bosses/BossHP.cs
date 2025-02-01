using System.Collections;
using UnityEngine;

public class BossHP : MonoBehaviour
{

    public float maxHP, HP;
    private float originalColorTimer, timeOnRed=0.75f;
    private bool attacked = false;
    [SerializeField] SpriteRenderer SpriteRenderer;
    public bool fase2 = false, firstTimeFase2 = true;
    private Color originalColor;
    //Ideia: Variavel global para trackear quantos bosses já foram derrotados pra ajustar o HP de cada paz

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
        //Script apenas por questões de debug abaixo
        if (attacked = true && originalColorTimer <= timeOnRed)
        {
            originalColorTimer += Time.deltaTime;
        }
        else
        {
            attacked = false;
            SpriteRenderer.color = originalColor;
            originalColorTimer = 0;
        }

    }


    public void Damage(float damage)
    {
        HP -= damage;
        
        if (!fase2 && HP <= (maxHP/2))
            fase2 = true;
        
        if(HP <= 0)
        {
            HP = 0;

            if(bossStateManager is JesterStateManager)
                JesterDeath();

            return;
        }

        //Script apenas por questões de debug abaixo
        SpriteRenderer.color = Color.magenta;
        attacked = true;
    }

    void JesterDeath()
    {
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
}
