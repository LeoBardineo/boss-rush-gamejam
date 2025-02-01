using UnityEngine;

// Ganha buff pros próximos 5 hits, se não acertar até o fim da pot, toma dano
class BananaSplit : Potion {
    int amountOfHits = 5, damageAfterFail = 1;
    float damageModifier = 1.5f;

    PlayerHP playerHP;

    Weapon weapon;

    protected override void Initialize()
    {
        base.Initialize();
        playerHP = GetComponent<PlayerHP>();
        weapon = playerController.equipedWeapon;
        damageModifier = GlobalData.potionsData["Hits"][0];
        amountOfHits = (int) GlobalData.potionsData["Hits"][1];
        buffDuration = GlobalData.potionsData["Hits"][2];
        damageAfterFail = (int) GlobalData.potionsData["Hits"][3];
        cooldownTime = GlobalData.potionsData["Hits"][4];
    }

    public override void EnterPotion(){
        Debug.Log("BananaSplit: começou o buff");
        weapon.bananaSplitEffect = true;
        weapon.bananaSplitAmountOfHits = amountOfHits;
        weapon.bananaSplitModifier = damageModifier;
        weapon.ChangeAttackAreaModifiers();
    }

    public override void EndPotion(){
        Debug.Log("BananaSplit: acabou o buff");
        
        if(weapon.bananaSplitEffect)
            playerHP.TakeDamage(damageAfterFail);
        
        weapon.bananaSplitEffect = false;
        weapon.bananaSplitAmountOfHits = 0;
        weapon.bananaSplitModifier = 1f;
        weapon.ChangeAttackAreaModifiers();
    }
}