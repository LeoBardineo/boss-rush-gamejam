using UnityEngine;

// Aumenta o dano, diminui a vida máxima
class Croissant : Potion {
    int reducedMaxHP = 2;

    float damageModifier = 2;

    PlayerHP playerHP;

    Weapon weapon;

    protected override void Initialize()
    {
        base.Initialize();
        playerHP = GetComponent<PlayerHP>();
        weapon = playerController.equipedWeapon;
        damageModifier = GlobalData.potionsData["DanoHP"][0];
        buffDuration = GlobalData.potionsData["DanoHP"][1];
        reducedMaxHP = (int) GlobalData.potionsData["DanoHP"][2];
        cooldownTime = GlobalData.potionsData["DanoHP"][3];
    }

    public override void EnterPotion(){
        Debug.Log("Croissant: começou o buff");
        playerHP.ChangeMaxHP(-reducedMaxHP);
        weapon.damageModifier = damageModifier;
        weapon.ChangeAttackAreaModifiers();
    }

    public override void EndPotion(){
        Debug.Log("Croissant: acabou o buff");
        playerHP.ChangeMaxHP(reducedMaxHP);
        weapon.damageModifier = 1f;
        weapon.ChangeAttackAreaModifiers();
    }
}