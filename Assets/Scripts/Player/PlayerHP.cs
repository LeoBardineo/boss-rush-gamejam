using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public float HP, maxHP;
    public bool invicible;
    public bool canTakeDamage=false;
    public static bool dead = false;
    float damageModifier = 1;

    //Pra alterar o tempo que o player fica invencível após tomar um dano é só alterar abaixo
    [SerializeField]
    private float invicibleDuration = 1.7f, time;

    [SerializeField]
    GameObject deathPanel;

    [SerializeField]
    string deathAnimationName;

    Animator animator;

    private SpriteRenderer sprite;

    [SerializeField]
    GameObject HealthPanel;

    [SerializeField]
    Sprite mascaraFull, mascaraMetade,  mascaraVazia;
    
    Image[] mascaras;

    void Start()
    {
        maxHP = GlobalData.playerData["HP"][GlobalData.level];
        HP = maxHP;

        dead = false;
        deathPanel.SetActive(false);
        animator = GetComponent<Animator>();

        mascaras = HealthPanel.GetComponentsInChildren<Image>(includeInactive : true);
        UpdateHealthUI();
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
        if (!invicible && !dead)
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
        dead = true;
        animator.Play(deathAnimationName);
        deathPanel.SetActive(true);
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
