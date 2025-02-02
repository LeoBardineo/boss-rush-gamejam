using System.Collections;
using UnityEngine;

public class DialogueRoletaTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] TextAsset introInkJSON, pierrotEscolhido, jesterEscolhido, harlequinEscolhido;

    void Start()
    {
        Debug.Log("startou");
        StartCoroutine(ComecaDialogo(introInkJSON, false, "", 2f));
    }

    IEnumerator ComecaDialogo(TextAsset inkJSON, bool vaiPraCena, string nomeCena, float tempoEspera)
    {
        yield return new WaitForSeconds(tempoEspera);
        if(vaiPraCena)
        {
            DialogueManager.GetInstance().vaiPraCena = true;
            DialogueManager.GetInstance().nomeCena = nomeCena;
        }
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }

    public void ComecaDialogoFinal(string nomeBoss)
    {
        TextAsset inkJSON;
        
        if(nomeBoss == "Pierrot")
        {
            inkJSON = pierrotEscolhido;
        }
        else if(nomeBoss == "Jester")
        {
            inkJSON = jesterEscolhido;
        }
        else
        {
            inkJSON = harlequinEscolhido;
        }

        string nomeCena = GlobalData.cenasBossFights[nomeBoss];
        StartCoroutine(ComecaDialogo(inkJSON, true, nomeCena, 1.5f));
    }
}
