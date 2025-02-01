using UnityEngine;

public class BlazeArea : AttackArea
{
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
        damage = (int) GlobalData.skillsData["CospeFogo"][1];
    }
}
