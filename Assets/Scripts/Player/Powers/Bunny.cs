using UnityEngine;

class Bunny : Power
{
    [SerializeField]
    GameObject bunnyPrefab;

    [SerializeField]
    float spawnInterval = 0.5f, antecipationDuration = 0.5f;

    [SerializeField]
    GameObject chapeu, firePoint;

    protected override void Initialize()
    {
        base.Initialize();
        attackArea = bunnyPrefab.GetComponent<BunnyAttack>();
        cooldownTime = GlobalData.skillsData["Coelhos"][0];
    }
    
    public override void EnterPower()
    {
        if(playerController == null)
            playerController = GetComponent<PlayerController>();
        InvokeRepeating(nameof(SpawnBunny), antecipationDuration, spawnInterval);
        chapeu.SetActive(true);
        animator.Play(animationName);
    }
    
    public override void EndPower()
    {
        CancelInvoke(nameof(SpawnBunny));
        chapeu.SetActive(false);
    }

    void SpawnBunny()
    {
        Vector3 spawnPosition = firePoint.transform.position;
        GameObject bunnyInstance = Instantiate(bunnyPrefab, spawnPosition, bunnyPrefab.transform.rotation);
        BunnyAttack bunnyAttack = bunnyInstance.GetComponent<BunnyAttack>();
        bunnyAttack.damage = damage;
        bunnyAttack.damageModifier = damageModifier;
        if(!playerController.facingRight)
            bunnyAttack.velocidadeDeMovimeto *= -1;
    }
}