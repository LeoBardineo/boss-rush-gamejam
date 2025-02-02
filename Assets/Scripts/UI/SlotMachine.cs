using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] List<string> nomesArmas;
    [SerializeField] List<Sprite> imagensArmas;

    [SerializeField] List<string> nomesPoderes;
    [SerializeField] List<Sprite> imagensPoderes;

    [SerializeField] List<string> nomesPocoes;
    [SerializeField] List<Sprite> imagensPocoes;

    [SerializeField] List<Sprite> iconesHarlequin, iconesPierrot, iconesJester;

    [SerializeField] Image[] slotsImage;
    [SerializeField] float tempoDeGiro = 1.5f;
    
    [SerializeField] GameObject cortinaIn;
    
    string[] escolhas = new string[3];
    List<string>[] todosNomes = new List<string>[3];
    List<Sprite>[] todasImagens = new List<Sprite>[3];

    void Start()
    {
        // Harlequin, Pierrot, Jester
        // List<string> nomeBosses = new List<string>{"Harlequin", "Pierrot", "Jester"};
        // List<string> nomeBossesCompletos = nomeBosses.Except(GlobalData.bossDisponiveis).ToList();

        // Inicializar pelo inspetor
        // nomesArmas.Add("Martelo");
        // nomesPoderes.Add("CospeFogo");
        // nomesPocoes.Add("HP");

        if(!GlobalData.bossDisponiveis.Contains("Harlequin"))
        {
            nomesArmas.Add("Canhao");
            nomesPoderes.Add("Coelhos");
            nomesPocoes.Add("Poder");
            
            imagensArmas.Add(iconesHarlequin[0]);
            imagensPoderes.Add(iconesHarlequin[1]);
            imagensPocoes.Add(iconesHarlequin[2]);
        }
        
        if(!GlobalData.bossDisponiveis.Contains("Pierrot"))
        {
            nomesArmas.Add("Florzinha");
            nomesPoderes.Add("Nuvem");
            nomesPocoes.Add("DanoHP");

            imagensArmas.Add(iconesPierrot[0]);
            imagensPoderes.Add(iconesPierrot[1]);
            imagensPocoes.Add(iconesPierrot[2]);
        }

        if(!GlobalData.bossDisponiveis.Contains("Jester"))
        {
            nomesArmas.Add("Malabares");
            nomesPoderes.Add("Coringa");
            nomesPocoes.Add("Hits");

            imagensArmas.Add(iconesJester[0]);
            imagensPoderes.Add(iconesJester[1]);
            imagensPocoes.Add(iconesJester[2]);
        }

        todosNomes[0] = nomesArmas;
        todosNomes[1] = nomesPoderes;
        todosNomes[2] = nomesPocoes;

        todasImagens[0] = imagensArmas;
        todasImagens[1] = imagensPoderes;
        todasImagens[2] = imagensPocoes;

        // for (int i = 0; i < 3; i++){
        //     int indexImagemInicial = Random.Range(0, todasImagens[i].Count);
        //     slotsImage[i].sprite = todasImagens[i][indexImagemInicial];
        //     slotsImage[i].preserveAspect = true;
        // }
    }
    
    public void GirarSlots()
    {
        StartCoroutine(GirarSlot(0));
        StartCoroutine(GirarSlot(1));
        StartCoroutine(GirarSlot(2));
        StartCoroutine(FecharCortinas());
    }

    IEnumerator GirarSlot(int index)
    {
        List<string> nomes = todosNomes[index];
        List<Sprite> imagens = todasImagens[index];

        yield return new WaitForSeconds(tempoDeGiro);

        int escolhaFinal = Random.Range(0, nomes.Count);
        escolhas[index] =  nomes[escolhaFinal];
        slotsImage[index].sprite = imagens[escolhaFinal];

        if(index == 0)
            GlobalData.armaEquipada = escolhas[index];

        if(index == 1)
            GlobalData.poderEquipado = escolhas[index];

        if(index == 2)
            GlobalData.pocaoEquipada = escolhas[index];

        Debug.Log($"Slot {index + 1}: {escolhas[index]}");
    }

    IEnumerator FecharCortinas()
    {
        yield return new WaitForSeconds(6);
        cortinaIn.SetActive(true);
    }
}
