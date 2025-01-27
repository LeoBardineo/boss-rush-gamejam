class BallonSword : MeleeWeapon
{
    void Start()
    {
        if(attackArea == null)
            attackArea = GetComponentInChildren<BallonSwordAttackArea>(includeInactive: true);
    }
}
