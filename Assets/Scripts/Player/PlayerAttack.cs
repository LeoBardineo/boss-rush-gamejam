using System;
using UnityEngine;

[Obsolete("Classe antiga de ataque, usamos o Weapon agora", true)]
public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    private bool attacking = false, onCooldown = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;
    
    void Start()
    {
        attackArea=transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && !onCooldown)
        {
            Attack();
            onCooldown = true;
        }

        if(attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
                onCooldown = false;
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
