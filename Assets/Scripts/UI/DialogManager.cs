using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public GameObject[] messages; // Lista com os Canvas das mensagens
    private int currentIndex = 0; // Índice da mensagem atual

    public GameObject nextButton; // Botão de avançar
    public GameObject prevButton; // Botão de voltar

    void Start()
    {
        UpdateDialog(); // Atualiza a HUD no início
    }

    public void NextMessage()
    {
        if (currentIndex < messages.Length - 1)
        {
            messages[currentIndex].SetActive(false);
            currentIndex++;
            messages[currentIndex].SetActive(true);
        }
    }

    public void PreviousMessage()
    {
        if (currentIndex > 0)
        {
            messages[currentIndex].SetActive(false);
            currentIndex--;
            messages[currentIndex].SetActive(true);
        }
    }

    void UpdateDialog()
    {
        for (int i = 0; i < messages.Length; i++)
        {
            messages[i].SetActive(i == currentIndex);
        }
    }
}
