using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] List<string> resolutions;
    [SerializeField] TextMeshProUGUI resolutionText;
    List<Dictionary<string, int>> resolutionsDict = new List<Dictionary<string, int>>();
    int resolutionIndex = 0;

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
        UpdateResolutionText();
    }

    void UpdateResolutionText()
    {
        resolutionText.text = $"{resolutionsDict[resolutionIndex]["width"]} x {resolutionsDict[resolutionIndex]["height"]}";
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

        Screen.SetResolution(width, height, FullScreenMode.Windowed);

        UpdateResolutionText();
    }

    void ChangeMusicVolume()
    {

    }

    void ChangeSoundVolume()
    {

    }
}
