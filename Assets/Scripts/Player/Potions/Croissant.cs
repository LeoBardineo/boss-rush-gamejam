using UnityEngine;

// Aumenta o dano, diminui a vida máxima
class Croissant : Potion {
    [SerializeField]
    int reducedMaxHP = 2;

    [SerializeField]
    float damageModifier = 2;

    PlayerHP playerHP;

    Weapon weapon;

    protected override void Initialize()
    {
        base.Initialize();
        playerHP = GetComponent<PlayerHP>();
        weapon = playerController.equipedWeapon;
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