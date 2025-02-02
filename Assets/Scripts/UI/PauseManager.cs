using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    
    [SerializeField]
    private GameObject settingsPanel;

    public static bool isPaused = false, settingsOpened = false;

    [SerializeField]
    private Animator animator;

    void Start()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);    
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;    
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
}