using UnityEngine;

// Duplica o dano do poder, aumenta o tempo do cooldown do poder
class Lollipop : Potion {
    float powerDamageModifier = 2, cdPowerModifier = 1.5f;

    Power equipedPower;

    protected override void Initialize()
    {
        base.Initialize();
        powerDamageModifier = GlobalData.potionsData["Poder"][0];
        buffDuration = GlobalData.potionsData["Poder"][1];
        cdPowerModifier = GlobalData.potionsData["Poder"][2];
        cooldownTime = GlobalData.potionsData["Poder"][3];
    }

    public override void EnterPotion(){
        Debug.Log("Lollipop: começou o buff");
        equipedPower = playerController.equipedPower;
        equipedPower.damageModifier = powerDamageModifier;
        equipedPower.cooldownTime *= cdPowerModifier;
    }

    public override void EndPotion(){
        Debug.Log("Lollipop: acabou o buff");
        equipedPower.damageModifier = 1;
    }
}