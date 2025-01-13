using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] List<string> nomesArmas;
    [SerializeField] List<Sprite> imagensArmas;

    [SerializeField] List<string> nomesPoderes;
    [SerializeField] List<Sprite> imagensPoderes;

    [SerializeField] List<string> nomesPocoes;
    [SerializeField] List<Sprite> imagensPocoes;

    [SerializeField] Image[] slotsImage;
    [SerializeField] float tempoDeGiro = 1.5f;
    [SerializeField] float tempoEntreGiros = 0.5f;
    
    string[] escolhas = new string[3];
    List<string>[] todosNomes = new List<string>[3];
    List<Sprite>[] todasImagens = new List<Sprite>[3];

    void Start()
    {
        todosNomes[0] = nomesArmas;
        todosNomes[1] = nomesPoderes;
        todosNomes[2] = nomesPocoes;

        todasImagens[0] = imagensArmas;
        todasImagens[1] = imagensPoderes;
        todasImagens[2] = imagensPocoes;

        for (int i = 0; i < 3; i++){
            int indexImagemInicial = Random.Range(0, todasImagens[i].Count);
            slotsImage[i].sprite = todasImagens[i][indexImagemInicial];
            slotsImage[i].preserveAspect = true;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            GirarSlots();
        }
    }
    
    public void GirarSlots()
    {
        StartCoroutine(GirarSlot(0));
        StartCoroutine(GirarSlot(1));
        StartCoroutine(GirarSlot(2));
    }

    IEnumerator GirarSlot(int index)
    {
        List<string> nomes = todosNomes[index];
        List<Sprite> imagens = todasImagens[index];

        float tempoPassado = 0f; 
        int total = nomes.Count;

        while (tempoPassado < tempoDeGiro + index * tempoEntreGiros)
        {
            int escolhaAleatoria = Random.Range(0, total);
            slotsImage[index].sprite = imagens[escolhaAleatoria];
            tempoPassado += Time.deltaTime;
            yield return null;
        }

        int escolhaFinal = Random.Range(0, total);
        escolhas[index] =  nomes[escolhaFinal];
        slotsImage[index].sprite = imagens[escolhaFinal];

        Debug.Log($"Slot {index + 1}: {escolhas[index]}");
    }
}
