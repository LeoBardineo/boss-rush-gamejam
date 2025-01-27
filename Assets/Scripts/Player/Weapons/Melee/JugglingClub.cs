class JugglingClub : MeleeWeapon
{

    void Start()
    {
        if(attackArea == null)
            attackArea = GetComponent<JugglingClubAttackArea>();
    }

}
