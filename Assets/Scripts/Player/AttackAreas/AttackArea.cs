using System;
using UnityEngine;

public class AttackArea : MonoBehaviour
{    
    public int damage;
    public float damageModifier = 1f;
    
    public float bananaSplitModifier = 1f;
    public bool bananaSplitEffect = false;
    public int bananaSplitAmountOfHits = 0;

    protected virtual void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.GetComponent<BossHP>() != null)
        {
            BossHP BossHPAtual = collider.GetComponent<BossHP>();
            BossHPAtual.Damage(CalcDamage());
            Debug.Log("HP Atual:"+ BossHPAtual.HP);
        }

        if(collider.GetComponent<PausCard>() != null)
        {
            PausCard pausCard = collider.GetComponent<PausCard>();
            pausCard.TomarDano(CalcDamage());
            Debug.Log("HP da carta de PAUS: " + pausCard.cardHP);
        }

        if (collider.GetComponent<HarlequimTakeDamage>() != null)
        {
            HarlequimTakeDamage BossHPAtual = collider.GetComponent<HarlequimTakeDamage>();
            BossHPAtual.Damage(CalcDamage());
            Debug.Log("Dano harlss");
        }        
    }

    protected int CalcDamage()
    {
        if(bananaSplitEffect){
            damageModifier = bananaSplitModifier;
            bananaSplitAmountOfHits--;
            if(bananaSplitAmountOfHits == 0)
                bananaSplitEffect = false;
        }

        int newDamage = (int) Math.Floor(damage * damageModifier);
        Debug.Log("newDamage: " + newDamage + " damage: " + damage + " damageModifier: " + damageModifier);
        return newDamage;
    }
}
