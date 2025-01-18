using System.Collections;
using UnityEngine;

public class SpawnRainTears: MonoBehaviour
{
    public GameObject tearPrefab;
    public Transform spawnArea;
    public float spawnHeight = 1.5f;
    public float positionVariance = 1.5f;
    public float antecipationDuration = 2f;
    public float attackDuration = 5f;
    public float spawnInterval = 0.1f;
    public bool isSpawning = false;

    public void StartSpawning()
    {
        isSpawning = true;
        InvokeRepeating(nameof(SpawnTears), antecipationDuration, spawnInterval);
        StartCoroutine(WaitSpawning(antecipationDuration + attackDuration));
    }

    void SpawnTears()
    {
        Vector3 posicaoCentro = spawnArea.position;
        Vector3 dimensoes = spawnArea.localScale / 2;

        float posicaoX = Random.Range(-dimensoes.x, dimensoes.x);

        Vector3 posicaoAleatoria = new Vector3(posicaoCentro.x + posicaoX, posicaoCentro.y, posicaoCentro.z);
        Instantiate(tearPrefab, posicaoAleatoria, tearPrefab.transform.rotation);
    }

    IEnumerator WaitSpawning(float attackDuration)
    {
        yield return new WaitForSeconds(attackDuration);
        CancelInvoke(nameof(SpawnTears));
        isSpawning = false;
    }
}
