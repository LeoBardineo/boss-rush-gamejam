using UnityEngine;

// Cura 2 de HP
class Pie : Potion {
    [SerializeField]
    int healingPoints = 2;

    PlayerHP playerHP;

    protected override void Initialize()
    {
        base.Initialize();
        playerHP = GetComponent<PlayerHP>();
    }

    public override void EnterPotion(){
        playerHP.Heal(healingPoints);
    }

    public override void EndPotion(){
        
    }
}