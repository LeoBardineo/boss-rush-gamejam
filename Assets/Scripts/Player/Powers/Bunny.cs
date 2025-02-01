using UnityEngine;

class Bunny : Power
{
    [SerializeField]
    GameObject bunnyPrefab;

    [SerializeField]
    float spawnInterval = 0.5f, antecipationDuration = 0.5f;
    
    Transform player;

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
        player = playerController.transform;
        InvokeRepeating(nameof(SpawnBunny), antecipationDuration, spawnInterval);
    }
    
    public override void EndPower()
    {
        CancelInvoke(nameof(SpawnBunny));
    }

    void SpawnBunny()
    {
        Vector3 spawnPosition = player.position;
        GameObject bunnyInstance = Instantiate(bunnyPrefab, spawnPosition, bunnyPrefab.transform.rotation);
        BunnyAttack bunnyAttack = bunnyInstance.GetComponent<BunnyAttack>();
        bunnyAttack.damage = damage;
        bunnyAttack.damageModifier = damageModifier;
        if(!playerController.facingRight)
            bunnyAttack.velocidadeDeMovimeto *= -1;
    }
}