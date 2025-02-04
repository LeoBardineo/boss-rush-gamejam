using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryText : MonoBehaviour, IPointerEnterHandler
{
    public TextMeshProUGUI title, description;
    public string titleText, descriptionText, typeOfItem;

    void Start()
    {
        if(typeOfItem == "Arma"){
            titleText = GlobalData.icones[GlobalData.armaEquipada]["title"];
            descriptionText = GlobalData.icones[GlobalData.armaEquipada]["description"];
        }

        if(typeOfItem == "Poder"){
            titleText = GlobalData.icones[GlobalData.poderEquipado]["title"];
            descriptionText = GlobalData.icones[GlobalData.poderEquipado]["description"];
        }

        if(typeOfItem == "Pocao"){
            titleText = GlobalData.icones[GlobalData.pocaoEquipada]["title"];
            descriptionText = GlobalData.icones[GlobalData.pocaoEquipada]["description"];
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        title.text = titleText;
        description.text = descriptionText;
    }
}