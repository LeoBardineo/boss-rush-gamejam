using System;
using UnityEngine;

class Bang : Power
{
    [SerializeField]
    GameObject bangPrefab;
    
    Transform player;
    
    protected override void Initialize()
    {
        base.Initialize();
        attackArea = bangPrefab.GetComponent<BangArea>();
        cooldownTime = GlobalData.skillsData["BangBang"][0];
    }

    public override void EnterPower()
    {
        if(playerController == null)
            playerController = GetComponent<PlayerController>();
        player = playerController.transform;
        SpawnBang();
    }
    
    public override void EndPower()
    {
        
    }

    void SpawnBang()
    {
        Vector3 spawnPosition = player.position;
        GameObject bangInstance = Instantiate(bangPrefab, spawnPosition, bangPrefab.transform.rotation);
        BangArea bangArea = bangInstance.GetComponent<BangArea>();
        bangArea.damage = damage;
        bangArea.damageModifier = damageModifier;
        if(!playerController.facingRight)
            bangArea.velocidadeDeMovimeto *= -1;
    }
}