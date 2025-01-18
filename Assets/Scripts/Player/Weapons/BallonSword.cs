using UnityEngine;

public class BallonSword : MeleeWeapon
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        cooldownTime = 1.11f;
    }
}
