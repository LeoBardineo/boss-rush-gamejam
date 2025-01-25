using UnityEngine;

class Bang : Power
{
    [SerializeField]
    GameObject bangPrefab;
    
    Transform player;
    
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
        if(!playerController.facingRight)
            bangInstance.GetComponent<BangArea>().velocidadeDeMovimeto *= -1;
    }
}