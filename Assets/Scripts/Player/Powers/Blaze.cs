using UnityEngine;

class Blaze : Power {

    [SerializeField]
    GameObject powerArea;
    
    public override void EnterPower()
    {
        powerArea.SetActive(true);
    }
    
    public override void EndPower()
    {
        powerArea.SetActive(false);
    }

}