using UnityEngine;

public class BlazeArea : AttackArea
{
    public void Start()
    {
        damage = gameObject.GetComponentInParent<Blaze>().damage;
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
    }
}
