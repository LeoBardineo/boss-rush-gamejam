using System.Collections;
using UnityEngine;

public class EspadasSpawner : MonoBehaviour
{
    public GameObject espadas;
    public Transform spawnArea;

    [SerializeField]
    float antecipacaoOffsetDuration = 0.5f;

    void Start()
    {
        
    }

    public void SpawnEspadas()
    {
        StartCoroutine(EsperarAntecipacao());
    }

    IEnumerator EsperarAntecipacao()
    {
        Vector3 spawnPosition = new Vector3(spawnArea.position.x, spawnArea.position.y, spawnArea.position.z);
        GameObject cartaEspadas = Instantiate(espadas, spawnPosition, espadas.transform.rotation);
        EspadasAttack espadasAttack = cartaEspadas.GetComponentInChildren<EspadasAttack>();
        Animator animator = espadasAttack.gameObject.GetComponent<Animator>();
        espadasAttack.antecipacao = true;
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + antecipacaoOffsetDuration);
        espadasAttack.antecipacao = false;
    }
}
