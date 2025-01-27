class Hammer : MeleeWeapon
{

    void Start()
    {
        if(attackArea == null)
            attackArea = GetComponent<HammerAttackArea>();
    }

}
