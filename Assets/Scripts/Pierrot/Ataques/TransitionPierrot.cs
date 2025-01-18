using UnityEngine;

public class TransitionPierrot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private GameObject ground1Fase;
    [SerializeField]
    private GameObject ground2Fase;
    [SerializeField]
    private GameObject oceanOfTears;
    [SerializeField]
    private BossHP bossHP;
    bool firstTime = true;


    void Update()
    {
        if (bossHP.fase2 && firstTime)
        {
            transition();
            firstTime = false;
        }
    }
    public void transition()
    {
        ground1Fase.SetActive(false);
        ground2Fase.SetActive(true);
        oceanOfTears.SetActive(true);
    }
}
