class JugglingClub : MeleeWeapon
{
    protected override void Initialize()
    {
        base.Initialize();
        if(attackArea == null)
            attackArea = GetComponentInChildren<JugglingClubAttackArea>(includeInactive: true);
    }
}
