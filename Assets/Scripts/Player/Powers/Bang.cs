using UnityEngine;

class Bang : Power
{
    [SerializeField]
    GameObject bangPrefab;
    
    Transform player;
    
    protected override void EnterPower()
    {
        player = playerController.transform;
        SpawnBang();
    }
    
    protected override void EndPower()
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