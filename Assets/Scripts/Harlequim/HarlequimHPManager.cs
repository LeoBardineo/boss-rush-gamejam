using Unity.VisualScripting;
using UnityEngine;

public class HarlequimHPManager : MonoBehaviour
{

    public float maxHP, HP;
    private float originalColorTimer, timeOnRed=1f, iFrames, iFrameTotal=1f;
    private bool attacked = false, invincible=false;
    [SerializeField] SpriteRenderer SpriteRenderer;
    public bool fase2 = false, firstTimeFase2 = true;
    
    private Color originalColor;
    //Ideia: Variavel global para trackear quantos bosses já foram derrotados pra ajustar o HP de cada paz

    [SerializeField]
    PlayerController playerController;

    [SerializeField]
    BossStateManager bossStateManager;
    StateManager stateManager;

    void Start()
    {
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
            invincible = false;
            Debug.Log("Acabou invencibilidade");
        }

    }


    public void Damage(float damage, bool isHand)
    {
        if (!invincible)
        {
        HP -= damage;
        
        if (!fase2 && HP <= (maxHP/2))
            fase2 = true;
        
        if(HP <= 0)
        {
            HP = 0;

            if(bossStateManager is HarlequimStateManager)
            {
                HarlequimDeath();
                return ;
            }
        }

        //Script apenas por questões de debug abaixo
        if(!isHand)
        {
            attacked = true;
            SpriteRenderer.color = Color.magenta;
            Debug.Log("Tomou golpe:"+SpriteRenderer.color);
            Debug.Log("HP Atual:"+HP);
        }
        invincible = true;
        }
    }

    void HarlequimDeath()
    {

        stateManager.TransitionToState(new HarlequimDeathState(gameObject));
    }
}
