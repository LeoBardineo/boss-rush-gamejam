using Unity.VisualScripting;
using UnityEngine;

public class TransitionPierrot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]
    private GameObject oceanOfTears;
    [SerializeField]
    private BossHP bossHP;
    bool firstTime = true;


    void Update()
    {
        if(bossHP != null)
        {

            if (bossHP.fase2 && firstTime)
            {
                transition();
                firstTime = false;
            }
        }
    }
    public void transition()
    {
        //AQUI
        oceanOfTears.SetActive(true);
    }
}
