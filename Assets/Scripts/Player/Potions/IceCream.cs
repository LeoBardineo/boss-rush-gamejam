using UnityEngine;

// Cura, diminui o dano das armas
class IceCream : Potion {
    [SerializeField]
    int healingPoints = 4;

    [SerializeField]
    float damageModifier = 0.7f;

    PlayerHP playerHP;

    Weapon weapon;

    protected override void Initialize()
    {
        base.Initialize();
        playerHP = GetComponent<PlayerHP>();
        weapon = playerController.equipedWeapon;
    }

    public override void EnterPotion(){
        Debug.Log("IceCream: começou o buff");
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