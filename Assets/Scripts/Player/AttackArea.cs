using UnityEngine;

public class AttackArea : MonoBehaviour
{    
    protected int damage;

    protected virtual void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.GetComponent<BossHP>() != null)
        {
            BossHP BossHPAtual = collider.GetComponent<BossHP>();
            BossHPAtual.Damage(damage);
            Debug.Log("Tomei porrada");
            Debug.Log("HP Atual:"+ BossHPAtual.HP);
        }

        if(collider.GetComponent<PausCard>() != null)
        {
            PausCard pausCard = collider.GetComponent<PausCard>();
            pausCard.TomarDano(damage);
            Debug.Log("HP da carta de PAUS: " + pausCard.cardHP);
        }
    }
}
