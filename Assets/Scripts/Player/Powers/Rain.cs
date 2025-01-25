using System.Collections;
using UnityEngine;

class Rain : Power
{
    [SerializeField]
    GameObject rainPrefab;

    [SerializeField]
    float spawnInterval = 0.5f, antecipationDuration = 0.5f, attackDuration = 5f;
    
    [SerializeField]
    Transform boss;
    
    protected override void EnterPower()
    {
        InvokeRepeating(nameof(SpawnRain), antecipationDuration, spawnInterval);
        StartCoroutine(WaitSpawning(attackDuration));
    }
    
    protected override void EndPower()
    {
        CancelInvoke(nameof(SpawnRain));
    }

    IEnumerator WaitSpawning(float attackDuration)
    {
        yield return new WaitForSeconds(attackDuration);
        EndPower();
    }

    void SpawnRain()
    {
        Vector3 spawnPosition = boss.position + new Vector3(0, 2f, 0);
        Instantiate(rainPrefab, spawnPosition, rainPrefab.transform.rotation);
    }
}