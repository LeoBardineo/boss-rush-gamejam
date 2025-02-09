using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;  // Necessário para trabalhar com UI

public class PotionHUD : MonoBehaviour
{
    // public Image potion;
    public Image potionBarFill, potionIcon;  // A imagem do fill da barra de poder
    private PlayerController playerPotion;  // Referência ao script de poder do jogador
    string potionIconAddress;
    AsyncOperationHandle<Sprite> potionHandle;

    void Start()
    {
        // Localiza o GameObject do jogador e obtém o script PlayerPower
        playerPotion = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        if(potionIcon == null) return;
        
        potionIconAddress = GlobalData.icones[GlobalData.pocaoEquipada]["icon"];
        potionHandle = Addressables.LoadAssetAsync<Sprite>(potionIconAddress);
        potionHandle.Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                potionIcon.sprite = handle.Result;
            }
            else
            {
                Debug.LogError("Falha ao carregar o ícone de poção.");
            }
        };
    }

    void Update()
    {
        // Atualiza o fill da barra de poder de acordo com o cooldown
        if (playerPotion != null)
        {
            potionBarFill.fillAmount = 1-playerPotion.GetPotionCooldownPercentage();
        }
    }

    void OnDestroy()
    {
        if(potionHandle.IsValid())
            Addressables.Release(potionHandle);
    }
}
