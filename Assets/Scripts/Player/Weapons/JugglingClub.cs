using UnityEngine;

public class JugglingClub : MeleeWeapon
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
        cooldownTime = 1.4f;
    }
}
