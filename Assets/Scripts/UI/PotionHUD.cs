using UnityEngine;
using UnityEngine.UI;  // Necessário para trabalhar com UI

public class PotionHUD : MonoBehaviour
{
    // public Image potion;
    public Image potionBarFill;  // A imagem do fill da barra de poder
    private PlayerController playerPotion;  // Referência ao script de poder do jogador

    void Start()
    {
        // Localiza o GameObject do jogador e obtém o script PlayerPower
        playerPotion = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        // Atualiza o fill da barra de poder de acordo com o cooldown
        if (playerPotion != null)
        {
            potionBarFill.fillAmount = 1-playerPotion.GetPotionCooldownPercentage();
        }
    }
}
