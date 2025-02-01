using UnityEngine;

// Cura 2 de HP
class Pie : Potion {
    int healingPoints = 2;

    PlayerHP playerHP;

    protected override void Initialize()
    {
        base.Initialize();
        playerHP = GetComponent<PlayerHP>();
        healingPoints = (int) GlobalData.potionsData["HP"][0];
        cooldownTime = GlobalData.potionsData["HP"][2];
    }

    public override void EnterPotion(){
        playerHP.Heal(healingPoints);
    }

    public override void EndPotion(){
        
    }
}