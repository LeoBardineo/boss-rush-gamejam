using UnityEngine;

public class AttackArea : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
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
    }
}
