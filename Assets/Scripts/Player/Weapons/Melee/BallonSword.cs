class BallonSword : MeleeWeapon
{

    void Start()
    {
        if(attackArea == null)
            attackArea = GetComponent<BallonSwordAttackArea>();
    }

}
