using UnityEngine;

public class Hammer : MeleeWeapon
{
    public override void Start()
    {
        ModifyCooldown();
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    public void ModifyCooldown()
    {
        cooldownTime = 1f;
    }
}
