using System.Collections;
using Ink.Runtime;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject dialoguePanel, cortinaIn;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] float typingSpeed = 0.04f;
    public SceneManagementUtilitys sceneManagementUtilitys;
    Coroutine displayLineCoroutine;
    
    public bool vaiPraCena = true;

    private Story currentStory;

    public bool dialogueIsPlaying, textTyping = false, breakTyping = false;

    public static bool liberaEspaco = true;

    public string nomeCena;
    
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
            if(!textTyping) {
                ContinueStory();
                return;
            }
            breakTyping = true;
        }
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        liberaEspaco = false;
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        Debug.Log("entrou");

        ContinueStory();
    }

    void ExitDialogueMode()
    {
        Debug.Log("saiu");
        StartCoroutine(LiberaApertarEspaco());
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        if(vaiPraCena)
        {
            cortinaIn.SetActive(true);
            Debug.Log("indo pra cena " + nomeCena);
            sceneManagementUtilitys.SceneName = nomeCena;
            sceneManagementUtilitys.LoadSceneStringWithTimer(1f);
        }
    }

    IEnumerator LiberaApertarEspaco()
    {
        yield return new WaitForSeconds(0.5f);
        liberaEspaco = true;
    }

    void ContinueStory()
    {
        if(currentStory.canContinue)
        {
            if(displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
        }
        else
        {
            ExitDialogueMode();
        }
    }

    IEnumerator DisplayLine(string line)
    {
        textTyping = true;
        breakTyping = false;
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            if(breakTyping)
            {
                dialogueText.text = line;
                break;
            }
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        textTyping = false;
    }
}
