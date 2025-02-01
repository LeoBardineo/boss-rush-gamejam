using Ink.Runtime;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TextMeshProUGUI dialogueText;

    private Story currentStory;

    bool dialogueIsPlaying;
    
    static DialogueManager instance;
    
    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("mais de um dialogue manager na cena");
        }
        instance = this;
    }

    void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if(!dialogueIsPlaying) return;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("espaço");
            ContinueStory();
        }
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        Debug.Log("entrou");

        ContinueStory();
    }

    void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    void ContinueStory()
    {
        if(currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogueMode();
        }
    }
}
