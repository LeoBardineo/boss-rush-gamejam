using UnityEngine;

class Blaze : Power {

    [SerializeField]
    GameObject powerArea;
    
    protected override void EnterPower()
    {
        powerArea.SetActive(true);
    }
    
    protected override void EndPower()
    {
        powerArea.SetActive(false);
    }

}