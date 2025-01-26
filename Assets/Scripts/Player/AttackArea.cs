using System;
using UnityEngine;

public class AttackArea : MonoBehaviour
{    
    public int damage;
    public float damageModifier = 1f;
    
    public float bananaSplitModifier;
    public bool bananaSplitEffect = false;
    public int bananaSplitAmountOfHits;

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
