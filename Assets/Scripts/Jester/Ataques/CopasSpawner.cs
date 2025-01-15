using System.Collections;
using UnityEngine;

public class CopasSpawner : MonoBehaviour
{
    public GameObject copas;
    public Transform player;
    public float antecipationDuration = 0.5f;
    public float attackDuration = 10f;
    public float spawnInterval = 1f;
    public bool isSpawning = false;

    public void StartSpawning()
    {
        isSpawning = true;
        InvokeRepeating(nameof(SpawnCopas), antecipationDuration, spawnInterval);
        StartCoroutine(WaitSpawning(attackDuration));
    }

    public void SpawnCopas()
    {
        copas.GetComponent<CopasAttack>().player = player;
        Vector3 spawnPosition = new Vector3(player.position.x, player.position.y, player.position.z);
        Instantiate(copas, spawnPosition, copas.transform.rotation);
    }

    IEnumerator WaitSpawning(float attackDuration)
    {
        yield return new WaitForSeconds(attackDuration);
        CancelInvoke(nameof(SpawnCopas));
        isSpawning = false;
    }
}
