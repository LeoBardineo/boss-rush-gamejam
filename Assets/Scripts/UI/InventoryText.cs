using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryText : MonoBehaviour, IPointerEnterHandler
{
    public TextMeshProUGUI UIText;
    
    [TextArea(3, 10)]
    public string hoverText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        UIText.text = hoverText;
    }
}