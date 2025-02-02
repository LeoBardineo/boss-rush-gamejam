using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueJackpotTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] TextAsset inkJSON;
    [SerializeField] Button botao;

    public static bool travaJackpot = true;

    void Start()
    {
        Debug.Log(GlobalData.primeiraVezJackpot);
        if(GlobalData.primeiraVezJackpot)
        {
            StartCoroutine(ComecaDialogo());
            GlobalData.primeiraVezJackpot = false;
        }else{
            botao.enabled = true;
        }
    }

    IEnumerator ComecaDialogo()
    {
        yield return new WaitForSeconds(1.5f);
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        travaJackpot = false;
    }
}
