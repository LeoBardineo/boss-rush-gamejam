using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] List<string> resolutions;
    [SerializeField] TextMeshProUGUI resolutionText, fullscreenText;
    int resolutionIndex = 0, fullscreenIndex = 0;

    List<Dictionary<string, int>> resolutionsDict = new List<Dictionary<string, int>>();

    List<string> fullScreenModesKeys;
    Dictionary<string, FullScreenMode> fullScreenModes = new(){
        {"Windowed", FullScreenMode.Windowed},
        {"Maximized Window", FullScreenMode.MaximizedWindow},
        {"Window fullscreen", FullScreenMode.FullScreenWindow},
        {"Fullscreen", FullScreenMode.ExclusiveFullScreen},
    };

    void Start()
    {
        foreach(string res in resolutions)
        {
            string[] resolution = res.Split('x');

            Dictionary<string, int> resolutionMap = new Dictionary<string, int>{
                {"width", int.Parse(resolution[0].Trim())},
                {"height", int.Parse(resolution[1].Trim())}
            };

            resolutionsDict.Add(resolutionMap);
        }
        fullScreenModesKeys = new List<string>(fullScreenModes.Keys);
        fullscreenIndex = fullScreenModesKeys.IndexOf(GetCurrentFullscreenMode());
        UpdateTexts();
    }

    void UpdateTexts()
    {
        resolutionText.text = $"{resolutionsDict[resolutionIndex]["width"]} x {resolutionsDict[resolutionIndex]["height"]}";
        fullscreenText.text = fullScreenModesKeys[fullscreenIndex];
    }

    public void ChangeResolution(int direction)
    {
        resolutionIndex += direction;

        if (resolutionIndex < 0)
            resolutionIndex = resolutionsDict.Count - 1;
        else if (resolutionIndex >= resolutionsDict.Count)
            resolutionIndex = 0;

        int width = resolutionsDict[resolutionIndex]["width"];
        int height = resolutionsDict[resolutionIndex]["height"];
        FullScreenMode currentMode = fullScreenModes[fullScreenModesKeys[fullscreenIndex]];

        Screen.SetResolution(width, height, currentMode);

        UpdateTexts();
    }

    public void ChangeFullscreen(int direction)
    {
        fullscreenIndex += direction;

        if (fullscreenIndex < 0)
            fullscreenIndex = fullScreenModesKeys.Count - 1;
        else if (fullscreenIndex >= fullScreenModesKeys.Count)
            fullscreenIndex = 0;

        FullScreenMode newMode = fullScreenModes[fullScreenModesKeys[fullscreenIndex]];
        Screen.SetResolution(Screen.width, Screen.height, newMode);

        UpdateTexts();
    }

    string GetCurrentFullscreenMode()
    {
        FullScreenMode currentMode = Screen.fullScreenMode;

        foreach (var mode in fullScreenModes)
        {
            if (mode.Value == currentMode)
                return mode.Key;
        }

        return "Windowed";
    }
}
