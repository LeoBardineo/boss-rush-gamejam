using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Roleta : MonoBehaviour
{
    [SerializeField] float tempoDeGiro = 2.0f, tempoParado = 1f;
    [SerializeField] float minVInicial, maxVInicial;
    [SerializeField] int numDeEscolhas = 3;
    [SerializeField] string harlequinBossFight, pierrotBossFight, jesterBossFight;
    [SerializeField] Image rostosRoleta2, rostoRoleta1;
    [SerializeField] Sprite HarlequinJester, PierrotJester, HarlequinPierrot, HarlequinIcon, PierrotIcon, JesterIcon;
    [SerializeField] SceneManagementUtilitys sceneManagementUtilitys;
    [SerializeField] GameObject cortinaIN;
    [SerializeField] DialogueRoletaTrigger dialogueRoletaTrigger;

    int escolha;
    bool girando = true;

    void Start()
    {
        MudarIcones();
        StartCoroutine(EsperaSubir());
    }

    IEnumerator EsperaSubir()
    {
        yield return new WaitForSeconds(2f);
        girando = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(GlobalData.roletaButton) && !DialogueManager.GetInstance().dialogueIsPlaying && DialogueManager.liberaEspaco)
        {
            IniciarGiro();
        }
    }

    public void IniciarGiro()
    {
        if (!girando)
        {
            StartCoroutine(GirarRoleta());
        }
    }

    IEnumerator GirarRoleta()
    {
        girando = true;
        float tempoPassado = 0f;
        float velocidadeInicial = UnityEngine.Random.Range(minVInicial, maxVInicial);
        float velocidadeFinal = 0f;

        while (tempoPassado < tempoDeGiro)
        {
            float progresso = tempoPassado / tempoDeGiro;
            float velocidadeAtual = Mathf.Lerp(velocidadeInicial, velocidadeFinal, Mathf.SmoothStep(0f, 1f, progresso));
            transform.Rotate(0f, 0f, velocidadeAtual * Time.deltaTime);
            tempoPassado += Time.deltaTime;
            yield return null;
        }
        
        float anguloFinal = transform.eulerAngles.z % 360;
        TirarDaBorda(anguloFinal);

        yield return new WaitForSeconds(tempoParado);

        escolha = Escolher(anguloFinal);
        MudarParaBossFight();
    }

    int Escolher(float angulo)
    {
        if(numDeEscolhas == 3){
            if (angulo >= 300 || angulo < 60) return 1;
            if (angulo >= 60 && angulo < 180) return 2;
            return 3;
        }

        if(numDeEscolhas == 2)
        {
            if(angulo >= 270 || angulo < 90) return 1;
            return 2;
        }

        if(numDeEscolhas == 1)
        {
            return 1;
        }

        return 0;
    }

    void TirarDaBorda(float anguloFinal)
    {
        if(numDeEscolhas == 3){
            if(
                (anguloFinal > 59 && anguloFinal < 64) ||
                (anguloFinal > 177 && anguloFinal < 181) ||
                (anguloFinal > 296 && anguloFinal < 300)
            ){
                transform.Rotate(0f, 0f, 10f * Time.deltaTime);
            }
        }
    }

    void MudarParaBossFight()
    {
        string bossName = GlobalData.bossDisponiveis[escolha - 1];

        if(bossName == "Harlequin")
        {
            GlobalData.bossDisponiveis.Remove("Harlequin");
        }

        if(bossName == "Pierrot")
        {
            GlobalData.bossDisponiveis.Remove("Pierrot");
        }

        if(bossName == "Jester")
        {
            GlobalData.bossDisponiveis.Remove("Jester");
        }

        dialogueRoletaTrigger.ComecaDialogoFinal(bossName);
        Debug.Log($"A roleta parou na escolha: {escolha} - {bossName}");
    }

    void MudarIcones()
    {
        if(numDeEscolhas == 3) return;

        if(numDeEscolhas == 2)
        {
            string boss1 = GlobalData.bossDisponiveis[0], boss2 = GlobalData.bossDisponiveis[1];
            if(boss1 == "Harlequin" && boss2 == "Jester"){
                rostosRoleta2.sprite = HarlequinJester;
            }
            
            if(boss1 == "Pierrot" && boss2 == "Jester"){
                rostosRoleta2.sprite = PierrotJester;
            }
            
            if(boss1 == "Harlequin" && boss2 == "Pierrot"){
                rostosRoleta2.sprite = HarlequinPierrot;
            }
        }

        if(numDeEscolhas == 1)
        {
            string boss = GlobalData.bossDisponiveis[0];
            if(boss == "Harlequin"){
                rostoRoleta1.sprite = HarlequinIcon;
            }
            
            if(boss == "Pierrot"){
                rostoRoleta1.sprite = PierrotIcon;
            }
            
            if(boss == "Jester"){
                rostoRoleta1.sprite = JesterIcon;
            }
        }
    }
}
