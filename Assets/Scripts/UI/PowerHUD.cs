using UnityEngine;
using UnityEngine.UI;  // Necessário para trabalhar com UI

public class PowerHUD : MonoBehaviour
{
    public Image powerBarFill;  // A imagem do fill da barra de poder
    private PlayerController playerPower;  // Referência ao script de poder do jogador

    void Start()
    {
        // Localiza o GameObject do jogador e obtém o script PlayerPower
        playerPower = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        // Atualiza o fill da barra de poder de acordo com o cooldown
        if (playerPower != null)
        {
            powerBarFill.fillAmount = playerPower.GetPowerCooldownPercentage();
        }
    }
}
