using UnityEngine;

public class RainAttack : AttackArea
{
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
        
        if(collider.CompareTag("Ground") || collider.GetComponent<BossHP>() != null)
        {
            Destroy(gameObject);
        }
    }
}
