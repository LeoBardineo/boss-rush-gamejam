using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject settingsCanvas;

    void Start()
    {
        
    }

    public void onSettingsClick()
    {
        settingsCanvas.SetActive(true);
    }

    public void onQuitClick()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
