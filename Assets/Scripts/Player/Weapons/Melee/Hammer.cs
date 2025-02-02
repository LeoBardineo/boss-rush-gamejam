class Hammer : MeleeWeapon
{

    protected override void Initialize()
    {
        base.Initialize();
        attackingAnimation = "Ataque_Martelo";
        if(attackArea == null)
            attackArea = GetComponentInChildren<HammerAttackArea>(includeInactive: true);
    }
}
