using System.Collections;
using UnityEngine;

public class DialogueWinTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] TextAsset harlequinWin, pierrotWin, jesterWin, allBossWin;
    TextAsset inkJSON;

    void Start()
    {
        if(GlobalData.bossDisponiveis.Count == 0) {
            inkJSON = allBossWin;
            StartCoroutine(ComecaDialogo());
            return;
        }
        
        if(GlobalData.ultimoBoss == "Harlequin") inkJSON = harlequinWin;
        if(GlobalData.ultimoBoss == "Pierrot") inkJSON = pierrotWin;
        if(GlobalData.ultimoBoss == "Jester") inkJSON = jesterWin;
        StartCoroutine(ComecaDialogo());
    }

    IEnumerator ComecaDialogo()
    {
        yield return new WaitForSeconds(1.5f);
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }
}
