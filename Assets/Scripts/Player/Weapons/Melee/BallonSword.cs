class BallonSword : MeleeWeapon
{
    protected override void Initialize()
    {
        base.Initialize();
        if(attackArea == null)
            attackArea = GetComponentInChildren<BallonSwordAttackArea>(includeInactive: true);
    }
}
