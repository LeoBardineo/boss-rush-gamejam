using UnityEngine;

public class PlayerHP : MonoBehaviour
{

    public float HP;
    public bool invicible;

    //Pra alterar o tempo que o player fica invencível após tomar um dano é só alterar abaixo
    [SerializeField]
    private float invicibleDuration=1.2f, time;

    private SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        if (GlobalData.level == 0)
        {
            HP = 10;
        }
        if (GlobalData.level == 1)
        {
            HP = 12;
        }
        if (GlobalData.level == 2)
        {
            HP = 14;
        }
        if (GlobalData.level == 3)
        {
            HP = 16;
        }
        if (GlobalData.level == 4)
        {
            HP = 18;
        }   
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
        if (HP > 0)
        {
            HP -= damage;
            invicible = true;
            HurtEffect();
        }
        else
        {
            Die();
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
}
