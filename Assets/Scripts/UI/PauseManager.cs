using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using TMPro;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    
    [SerializeField]
    private GameObject settingsPanel;

    public static bool isPaused = false, settingsOpened = false;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    Image weaponIcon, powerIcon, potionIcon;

    string weaponIconAddress;
    string powerIconAddress;
    string potionIconAddress;

    AsyncOperationHandle<Sprite> weaponHandle, powerHandle, potionHandle;

    void Start()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);    
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        weaponIconAddress = GlobalData.icones[GlobalData.armaEquipada]["icon"];
        powerIconAddress = GlobalData.icones[GlobalData.poderEquipado]["icon"];
        potionIconAddress = GlobalData.icones[GlobalData.pocaoEquipada]["icon"];
        LoadPauseIcons();
    }

    void Update()
    {
        if (Input.GetKeyDown(GlobalData.pauseButton))
        {
            if(settingsOpened)
            {
                ToggleSettings();
                return;
            }
            TogglePause();
        }
    }

    public void ToggleSettings()
    {
        settingsOpened = !settingsOpened;
        settingsPanel.SetActive(settingsOpened);
    }
    
    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0; 
        pausePanel.SetActive(true);
        animator.Play("PauseIN"); 
    }

    public void ResumeGame()
    {
        Time.timeScale = 1; 
        pausePanel.SetActive(false); 
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }

    void LoadPauseIcons()
    {
        weaponHandle = Addressables.LoadAssetAsync<Sprite>(weaponIconAddress);
        weaponHandle.Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                weaponIcon.sprite = handle.Result;
            }
            else
            {
                Debug.LogError("Falha ao carregar o ícone de arma.");
            }
        };

        powerHandle = Addressables.LoadAssetAsync<Sprite>(powerIconAddress);
        powerHandle.Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                powerIcon.sprite = handle.Result;
            }
            else
            {
                Debug.LogError("Falha ao carregar o ícone de poder.");
            }
        };

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

    void OnDestroy()
    {
        Addressables.Release(weaponHandle);
        Addressables.Release(powerHandle);
        Addressables.Release(potionHandle);
    }
}