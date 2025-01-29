using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    [SerializeField] List<GameObject> buttonsGroup;
    [SerializeField] List<GameObject> tabsGroup;
    Dictionary<string, string> buttonTab = new Dictionary<string, string>();
    [SerializeField] Color selectedColor, disabledColor;
    [SerializeField] GameObject settingsPanel;
    
    void Start()
    {
        for (int i = 0; i < tabsGroup.Count; i++)
        {
            buttonTab[buttonsGroup[i].name] = tabsGroup[i].name;
        }
    }

    public void onTabChange(GameObject buttonSelected)
    {
        // Se for o último, que é o de voltar, desativa o panel de settings
        if(buttonSelected.name == buttonsGroup[^1].name)
        {
            PauseManager.settingsOpened = false;
            settingsPanel.SetActive(false);
            return;
        }

        // Deixa apenas o botão selecionado ativo
        for (int i = 0; i < tabsGroup.Count; i++)
        {
            GameObject button = buttonsGroup[i];
            Button actualButton = button.GetComponent<Button>();
            ColorBlock buttonColors = actualButton.colors;
            buttonColors.normalColor = (button.name == buttonSelected.name) ? selectedColor : disabledColor;
            actualButton.colors = buttonColors;
        }

        // Deixa apenas a tab selecionada ativa
        string correctTab = buttonTab[buttonSelected.name];
        foreach (GameObject tab in tabsGroup)
        {
            tab.SetActive(tab.name == correctTab);
        }
    }
}
