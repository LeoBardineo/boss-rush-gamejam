using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public float HP, maxHP;
    public bool invicible;
    float damageModifier = 1;

    //Pra alterar o tempo que o player fica invencível após tomar um dano é só alterar abaixo
    [SerializeField]
    private float invicibleDuration = 1.2f, time;

    private SpriteRenderer sprite;

    void Start()
    {
        if (GlobalData.level == 0)
        {
            maxHP = 10;
        }
        if (GlobalData.level == 1)
        {
            maxHP = 12;
        }
        if (GlobalData.level == 2)
        {
            maxHP = 14;
        }
        if (GlobalData.level == 3)
        {
            maxHP = 16;
        }
        if (GlobalData.level == 4)
        {
            maxHP = 18;
        }
        HP = maxHP;
    }

    void Update()
    {
        if (invicible)
        {
            time += Time.deltaTime;
            if (time >= invicibleDuration)
            {
                invicible = false;
                time = 0;
                sprite.color = Color.white;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if (!invicible)
        {
            HP -= damage * damageModifier;
            if (HP > 0)
            {
                invicible = true;
                HurtEffect();
            }
            else
            {
                HP = 0;
                Die();
            }
        }
    }

    void Die()
    {
        Debug.Log("fucking dies");
    }

    void HurtEffect()
    {
        if (GetComponentInChildren<SpriteRenderer>()!= null)
        {
            sprite = GetComponentInChildren<SpriteRenderer>();
            sprite.color = Color.red;
            Debug.Log("Hurt change");
        }
    }

    public void Heal(int healingPoints)
    {
        HP += healingPoints;
        if(HP > maxHP)
            HP = maxHP;
    }

    public void ChangeMaxHP(int healingPoints)
    {
        maxHP += healingPoints;
    }
}
