using UnityEngine;

public abstract class BossStateManager : MonoBehaviour
{
    public StateManager stateManager;
    public float idleDuration;
    public IState lastUsedAttack;

    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    string cenaGanhou;

    void Update()
    {
        stateManager.Update();
    }

    public void BossDeath()
    {
        StartCoroutine(gameManager.CarregaCena(cenaGanhou));
    }
}