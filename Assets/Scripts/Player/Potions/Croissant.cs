using UnityEngine;

// Aumenta o dano, diminui a vida máxima
class Croissant : Potion {
    [SerializeField]
    int reducedMaxHP = 2;

    [SerializeField]
    float damageModifier = 2;

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
        Debug.Log("Croissant: começou o buff");
        playerHP.ChangeMaxHP(-reducedMaxHP);
        attackArea.damageModifier = damageModifier;
    }

    public override void EndPotion(){
        Debug.Log("Croissant: acabou o buff");
        playerHP.ChangeMaxHP(reducedMaxHP);
        attackArea.damageModifier = 1;
    }
}