using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public float HP, maxHP;
    public bool invicible;
    float damageModifier = 1;

    //Pra alterar o tempo que o player fica invencível após tomar um dano é só alterar abaixo
    [SerializeField]
    private float invicibleDuration = 1.2f, time;

    private SpriteRenderer sprite;

    [SerializeField]
    GameObject HealthPanel;

    [SerializeField]
    Sprite mascaraFull, mascaraMetade,  mascaraVazia;
    
    Image[] mascaras;

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
        mascaras = HealthPanel.GetComponentsInChildren<Image>(includeInactive : true);
        UpdateHealthUI();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
            UpdateHealthUI();
        
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
                UpdateHealthUI();
                HurtEffect();
            }
            else
            {
                HP = 0;
                UpdateHealthUI();
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
        UpdateHealthUI();
    }

    public void ChangeMaxHP(int healingPoints)
    {
        maxHP += healingPoints;
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        for (int i = 1; i <= mascaras.Length; i++)
        {
            Image mascara = mascaras[i - 1];
            if(i > maxHP / 2)
            {
                mascara.gameObject.SetActive(false);
                continue;
            } else {
                mascara.gameObject.SetActive(true);
            }

            if (i <= HP / 2) {
                mascara.sprite = mascaraFull;
            } else {
                mascara.sprite = mascaraVazia;
            }

            if(i == Math.Ceiling(HP / 2) && HP % 2 == 1) {
                Debug.Log("mascara metade");
                mascara.sprite = mascaraMetade;
            }
        }
    }
}
