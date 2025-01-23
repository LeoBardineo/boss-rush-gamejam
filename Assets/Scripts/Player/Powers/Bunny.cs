using UnityEngine;

class Bunny : Power
{
    [SerializeField]
    GameObject bunnyPrefab;

    [SerializeField]
    float spawnInterval = 0.5f, antecipationDuration = 0.5f;
    
    Transform player;
    
    protected override void EnterPower()
    {
        player = playerController.transform;
        InvokeRepeating(nameof(SpawnBunny), antecipationDuration, spawnInterval);
    }
    
    protected override void EndPower()
    {
        CancelInvoke(nameof(SpawnBunny));
    }

    void SpawnBunny()
    {
        Vector3 spawnPosition = player.position;
        Instantiate(bunnyPrefab, spawnPosition, bunnyPrefab.transform.rotation);
    }
}