using UnityEngine;

class Blaze : Power {
    [SerializeField]
    BlazeArea powerArea;
    [SerializeField] AudioSource sound;
    protected override void Initialize()
    {
        base.Initialize();
        attackArea = powerArea;
        cooldownTime = GlobalData.skillsData["CospeFogo"][0];
    }
    
    public override void EnterPower()
    {
        sound.Play();
        animator.Play(animationName);
        powerArea.damage = damage;
        powerArea.damageModifier = damageModifier;
        powerArea.gameObject.SetActive(true);
    }
    
    public override void EndPower()
    {
        powerArea.gameObject.SetActive(false);
    }

}