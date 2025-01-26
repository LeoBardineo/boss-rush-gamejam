using System.Collections;
using UnityEngine;

class Rain : Power
{
    [SerializeField]
    GameObject rainPrefab;

    [SerializeField]
    float spawnInterval = 0.5f, antecipationDuration = 0.5f, horizontalVariance = 2f, verticalVariance = 0.5f, verticalOffset = 2f;
    
    [SerializeField]
    Transform boss;

    protected override void Initialize()
    {
        base.Initialize();
        attackArea = rainPrefab.GetComponent<RainAttack>();
    }
    
    public override void EnterPower()
    {
        RainAttack rainAttack = rainPrefab.GetComponent<RainAttack>();
        rainAttack.damage = damage;
        rainAttack.damageModifier = damageModifier;
        InvokeRepeating(nameof(SpawnRain), antecipationDuration, spawnInterval);
    }
    
    public override void EndPower()
    {
        CancelInvoke(nameof(SpawnRain));
    }

    void SpawnRain()
    {
        float randomX = Random.Range(-horizontalVariance, horizontalVariance);
        float randomY = Random.Range(-verticalVariance, verticalVariance);
        Vector3 spawnPosition = boss.position + new Vector3(randomX, randomY + verticalOffset, 0);
        Instantiate(rainPrefab, spawnPosition, rainPrefab.transform.rotation);
    }
}