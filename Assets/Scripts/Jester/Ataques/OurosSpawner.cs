using System.Collections;
using UnityEngine;

public class OurosSpawner : MonoBehaviour
{
    public GameObject ourosPrefab;
    public Transform spawnArea;
    public float spawnHeight = 1.5f;
    public float positionVariance = 1.5f;
    public float antecipationDuration = 2f;
    public float attackDuration = 5f, secondPhaseWaitDuration = 1f;
    public float attackCooldown = 5f, attackCooldownRemaining = 0f;
    public float spawnInterval = 0.1f;
    public bool isSpawning = false;
    
    [SerializeField]
    AudioClip soundAntecipation;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartSpawning()
    {
        audioSource.PlayOneShot(soundAntecipation);
        isSpawning = true;
        InvokeRepeating(nameof(SpawnOuros), antecipationDuration, spawnInterval);
        StartCoroutine(WaitSpawning(antecipationDuration + attackDuration));
    }

    void Update()
    {
        if(!isSpawning && attackCooldownRemaining >= 0)
            attackCooldownRemaining -= Time.deltaTime;
    }

    void SpawnOuros()
    {
        Vector3 posicaoCentro = spawnArea.position;
        Vector3 dimensoes = spawnArea.localScale / 2;

        float posicaoX = Random.Range(-dimensoes.x, dimensoes.x);

        Vector3 posicaoAleatoria = new Vector3(posicaoCentro.x + posicaoX, posicaoCentro.y, posicaoCentro.z + posicaoX * 0.01f);
        Instantiate(ourosPrefab, posicaoAleatoria, ourosPrefab.transform.rotation);
    }

    IEnumerator WaitSpawning(float attackDuration)
    {
        yield return new WaitForSeconds(attackDuration);
        CancelInvoke(nameof(SpawnOuros));
        isSpawning = false;
        attackCooldownRemaining = attackCooldown;
    }

    public void StopSpawning()
    {
        isSpawning = false;
        CancelInvoke();
    }
}
