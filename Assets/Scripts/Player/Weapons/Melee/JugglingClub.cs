class JugglingClub : MeleeWeapon
{
    protected override void Initialize()
    {
        base.Initialize();
        attackingAnimation = "Ataque_Malabares";
        if(attackArea == null)
            attackArea = GetComponentInChildren<JugglingClubAttackArea>(includeInactive: true);
    }
}
