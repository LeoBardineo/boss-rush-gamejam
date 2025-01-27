class JugglingClub : MeleeWeapon
{
    void Start()
    {
        if(attackArea == null)
            attackArea = GetComponentInChildren<JugglingClubAttackArea>(includeInactive: true);
    }
}
