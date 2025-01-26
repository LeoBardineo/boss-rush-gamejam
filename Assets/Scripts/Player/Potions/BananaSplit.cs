using UnityEngine;

// Ganha buff pros próximos 5 hits, se não acertar até o fim da pot, toma dano
class BananaSplit : Potion {
    [SerializeField]
    int amountOfHits = 5, damageAfterFail = 1;
    
    [SerializeField]
    float damageModifier = 1.5f;

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
        Debug.Log("BananaSplit: começou o buff");
        attackArea.bananaSplitEffect = true;
        attackArea.bananaSplitAmountOfHits = amountOfHits;
        attackArea.bananaSplitModifier = damageModifier;
    }

    public override void EndPotion(){
        Debug.Log("BananaSplit: acabou o buff");
        if(attackArea.bananaSplitEffect)
            playerHP.TakeDamage(damageAfterFail);
    }
}