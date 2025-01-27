using UnityEngine;

public class JugglingClubAttackArea : AttackArea
{
   public void Start()
    {
        if (GlobalData.level == 0)
        {
            damage = 30;
        }
        if (GlobalData.level == 1)
        {
            damage = 32;
        }
        if (GlobalData.level == 2)
        {
            damage = 35;
        }
        if (GlobalData.level == 3)
        {
            damage = 38;
        }
        if (GlobalData.level == 4)
        {
            damage = 41;
        }     

        Debug.Log("Hammer DMG:"+ damage);
    }
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
    }
}
