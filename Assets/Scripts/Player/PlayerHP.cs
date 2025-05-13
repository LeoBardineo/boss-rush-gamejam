using System;
using System.Collections;
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
    private float invicibleDuration = 1.7f, transitionSpeed = 5f, time;

    [SerializeField]
    Color damageColor;

    [SerializeField]
    string deathAnimationName;

    Animator animator;

    private SpriteRenderer sprite;

    [SerializeField]
    GameObject HealthPanel;

    Sprite mascaraFull, mascaraMetade,  mascaraVazia;
    
    Image[] mascaras;

    [SerializeField]
    Sprite mascaraFull_X, mascaraMetade_X, mascaraVazia_X;
    [SerializeField]
    Sprite mascaraFull_Y, mascaraMetade_Y, mascaraVazia_Y;
    
    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    string cenaMorte;

    [SerializeField]
    AudioClip morteAudio;
    AudioSource audioSource;

    void Start()
    {
        maxHP = GlobalData.playerData["HP"][GlobalData.level];
        HP = maxHP;

        dead = false;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

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
        audioSource.PlayOneShot(morteAudio);
        StartCoroutine(gameManager.CarregaCena(GlobalData.cenasBossMortes[GlobalData.ultimoBoss]));
    }

    void HurtEffect()
    {
        if (GetComponentInChildren<SpriteRenderer>()!= null)
        {
            sprite = GetComponentInChildren<SpriteRenderer>();
            StartCoroutine(DamageFeedback());
        }
    }

    IEnumerator DamageFeedback()
    {
        float elapsedTime = 0f;
        
        while (elapsedTime < invicibleDuration)
        {
            float t = Mathf.PingPong(Time.time * transitionSpeed, 1f);
            sprite.color = Color.Lerp(Color.white, damageColor, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        sprite.color = Color.white;

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

            if (i > maxHP / 2)
            {
                mascara.gameObject.SetActive(false);
                continue;
            }
            else
            {
                mascara.gameObject.SetActive(true);
            }

            // Definir qual conjunto de sprites usar (X para ímpares, Y para pares)
            Sprite fullSprite = (i % 2 == 1) ? mascaraFull_X : mascaraFull_Y;
            Sprite metadeSprite = (i % 2 == 1) ? mascaraMetade_X : mascaraMetade_Y;
            Sprite vaziaSprite = (i % 2 == 1) ? mascaraVazia_X : mascaraVazia_Y;

            if (i <= HP / 2)
            {
                mascara.sprite = fullSprite;
                Debug.Log($"Sprite atribuído: {fullSprite.name}");
            }
            else
            {
                mascara.sprite = vaziaSprite;
                Debug.Log($"Sprite atribuído: {vaziaSprite.name}");
            }

            if (i == Mathf.CeilToInt(HP / 2f) && HP % 2 == 1)
            {
                Debug.Log("mascara metade");
                mascara.sprite = metadeSprite;
            }
        }
    }
}
