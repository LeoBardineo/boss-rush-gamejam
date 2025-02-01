using System.Collections;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] TextAsset inkJSON;

    void Start()
    {
        StartCoroutine(ComecaDialogo());
    }

    IEnumerator ComecaDialogo()
    {
        yield return new WaitForSeconds(0.5f);
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }
}
