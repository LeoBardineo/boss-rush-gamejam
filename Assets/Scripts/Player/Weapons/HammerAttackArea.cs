using UnityEngine;

public class HammerAttackArea : AttackArea
{
    
    public void Start()
    {
        if (GlobalData.level == 0)
        {
            damage = 25;
        }
        if (GlobalData.level == 1)
        {
            damage = 27;
        }
        if (GlobalData.level == 2)
        {
            damage = 30;
        }
        if (GlobalData.level == 3)
        {
            damage = 33;
        }
        if (GlobalData.level == 4)
        {
            damage = 36;
        }     

        Debug.Log("Hammer DMG:"+ damage);
    }
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
    }

    void ModifyDamage()
    {

    }
}
