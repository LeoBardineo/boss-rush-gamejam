using System.Collections;
using UnityEngine;

public class CopasSpawner : MonoBehaviour
{
    public GameObject copas;
    public Transform player;
    public float antecipationDuration = 0.5f;
    public float attackDuration = 10f, secondPhaseWaitDuration = 1f;
    public float attackCooldown = 5f, attackCooldownRemaining = 0f;
    public float spawnInterval = 1f;
    public bool isSpawning = false;

    void Update()
    {
        if(!isSpawning && attackCooldownRemaining >= 0)
            attackCooldownRemaining -= Time.deltaTime;
    }

    public void StartSpawning()
    {
        isSpawning = true;
        InvokeRepeating(nameof(SpawnCopas), antecipationDuration, spawnInterval);
        StartCoroutine(WaitSpawning(attackDuration));
    }

    public void SpawnCopas()
    {
        copas.GetComponent<CopasAttack>().player = player;
        Vector3 spawnPosition = new Vector3(player.position.x, player.position.y, player.position.x + player.position.z);
        Instantiate(copas, spawnPosition, copas.transform.rotation);
    }

    IEnumerator WaitSpawning(float attackDuration)
    {
        yield return new WaitForSeconds(attackDuration);
        CancelInvoke(nameof(SpawnCopas));
        isSpawning = false;
        attackCooldownRemaining = attackCooldown;
    }

    public void StopSpawning()
    {
        isSpawning = false;
        CancelInvoke();
    }
}
