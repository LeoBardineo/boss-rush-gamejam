using UnityEngine;

public class AttackArea : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private int damage = 20;

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.GetComponent<PierrotHP>() != null)
        {
            PierrotHP hp = collider.GetComponent<PierrotHP>();
            hp.Damage(damage);
            Debug.Log("Tomei porrada");
            Debug.Log("HP Atual:"+ hp.HP);
        }   
    }
}
