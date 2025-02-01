using UnityEngine;

public class JugglingClubAttackArea : AttackArea
{
   public void Start()
    {
        damage = (int) GlobalData.weaponsData["Malabares"][GlobalData.level];
        Debug.Log("Hammer DMG:"+ damage);
    }
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
    }
}
