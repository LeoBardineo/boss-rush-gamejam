using UnityEngine;

public class HammerAttackArea : AttackArea
{
    
    public void Start()
    {
        damage = (int) GlobalData.weaponsData["Martelo"][GlobalData.level];

        Debug.Log("Hammer DMG:"+ damage);
    }
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
    }
}
