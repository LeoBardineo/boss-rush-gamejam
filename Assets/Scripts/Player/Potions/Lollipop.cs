using UnityEngine;

// Duplica o dano do poder, aumenta o tempo do cooldown do poder
class Lollipop : Potion {
    [SerializeField]
    float powerDamageModifier = 2, cdPowerModifier = 1.5f;

    Power equipedPower;

    protected override void Initialize()
    {
        base.Initialize();
        equipedPower = playerController.equipedPower;
    }

    public override void EnterPotion(){
        Debug.Log("Lollipop: começou o buff");
        equipedPower.damageModifier = powerDamageModifier;
        equipedPower.cooldownTime *= cdPowerModifier;
    }

    public override void EndPotion(){
        Debug.Log("Lollipop: acabou o buff");
        equipedPower.damageModifier = 1;
    }
}