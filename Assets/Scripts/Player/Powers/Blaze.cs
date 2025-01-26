using UnityEngine;

class Blaze : Power {
    [SerializeField]
    BlazeArea powerArea;

    protected override void Initialize()
    {
        base.Initialize();
        attackArea = powerArea;
    }
    
    public override void EnterPower()
    {
        powerArea.damage = damage;
        powerArea.damageModifier = damageModifier;
        powerArea.gameObject.SetActive(true);
    }
    
    public override void EndPower()
    {
        powerArea.gameObject.SetActive(false);
    }

}