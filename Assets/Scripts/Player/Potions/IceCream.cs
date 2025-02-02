using UnityEngine;

// Cura, diminui o dano das armas
class IceCream : Potion {
    int healingPoints = 4;

    float damageModifier = 0.7f;

    PlayerHP playerHP;

    Weapon weapon;

    protected override void Initialize()
    {
        base.Initialize();
        playerHP = GetComponent<PlayerHP>();
        healingPoints = (int) GlobalData.potionsData["HPDano"][0];
        damageModifier = GlobalData.potionsData["HPDano"][1];
        buffDuration = GlobalData.potionsData["HPDano"][2];
        cooldownTime = GlobalData.potionsData["HPDano"][3];
    }

    public override void EnterPotion(){
        Debug.Log("IceCream: começou o buff");
        weapon = playerController.equipedWeapon;
        playerHP.Heal(healingPoints);
        weapon.damageModifier = damageModifier;
        weapon.ChangeAttackAreaModifiers();
    }

    public override void EndPotion(){
        Debug.Log("IceCream: acabou o buff");
        weapon.damageModifier = 1f;
        weapon.ChangeAttackAreaModifiers();
    }
}