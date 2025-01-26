using UnityEngine;

// Cura, diminui o dano das armas
class IceCream : Potion {
    [SerializeField]
    int healingPoints = 4;

    [SerializeField]
    float damageModifier = 0.7f;

    [SerializeField]
    AttackArea attackArea;

    PlayerHP playerHP;

    protected override void Initialize()
    {
        base.Initialize();
        playerHP = GetComponent<PlayerHP>();
        // attackArea = equipedWeapon.attackArea;
    }

    public override void EnterPotion(){
        Debug.Log("IceCream: começou o buff");
        playerHP.Heal(healingPoints);
        attackArea.damageModifier = damageModifier;
    }

    public override void EndPotion(){
        Debug.Log("IceCream: acabou o buff");
        attackArea.damageModifier = 1;
    }
}