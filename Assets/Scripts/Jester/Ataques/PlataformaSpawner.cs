using System.Collections;
using UnityEngine;

public class PlataformaSpawner : MonoBehaviour
{
    public float tempoInvisivel = 1f;

    [SerializeField]
    Transform spawnPointEsquerda, spawnPointMeio, spawnPointDireita;

    [SerializeField]
    GameObject plataformaEsquerda, plataformaMeio, plataformaDireita;

    Transform spawnPointEscolhido;
    GameObject plataformaEscolhida;
    SpriteRenderer sp;
    BoxCollider2D boxCollider2D;

    public int posAtual = 2;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void Spawnar(int posicaoEscolhida)
    {
        StartCoroutine(EsperaSpawn(posicaoEscolhida));
    }

    IEnumerator EsperaSpawn(int posicaoEscolhida)
    {
        sp.enabled = false;
        boxCollider2D.enabled = false;
        if(plataformaEscolhida != null)
            plataformaEscolhida.SetActive(false);

        yield return new WaitForSeconds(tempoInvisivel);
        Escolher(posicaoEscolhida);

        sp.enabled = true;
        boxCollider2D.enabled = true;
        transform.position = spawnPointEscolhido.position;
        plataformaEscolhida.SetActive(true);
    }

    void Escolher(int posicaoEscolhida)
    {
        if(posicaoEscolhida == 0)
        {
            spawnPointEscolhido = spawnPointEsquerda;
            plataformaEscolhida = plataformaEsquerda;
        }

        if(posicaoEscolhida == 1)
        {
            spawnPointEscolhido = spawnPointMeio;
            plataformaEscolhida = plataformaMeio;
        }

        if(posicaoEscolhida == 2)
        {
            spawnPointEscolhido = spawnPointDireita;
            plataformaEscolhida = plataformaDireita;
        }
    }
}
