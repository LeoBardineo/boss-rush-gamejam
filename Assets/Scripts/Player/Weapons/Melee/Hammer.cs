class Hammer : MeleeWeapon
{
    void Start()
    {
        if(attackArea == null)
            attackArea = GetComponentInChildren<HammerAttackArea>(includeInactive: true);
    }
}
