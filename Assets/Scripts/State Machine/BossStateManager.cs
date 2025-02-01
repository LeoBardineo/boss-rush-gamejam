using UnityEngine;

public abstract class BossStateManager : MonoBehaviour
{
    public StateManager stateManager;
    public float idleDuration;
    public IState lastUsedAttack;

    void Update()
    {
        stateManager.Update();
    }
}