using Unity.VisualScripting;
using UnityEngine;

public class TransitionPierrot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]
    private GameObject oceanOfTears;
    [SerializeField]
    private BossHP bossHP;

    public void transition()
    {
        oceanOfTears.SetActive(true);
    }
}
