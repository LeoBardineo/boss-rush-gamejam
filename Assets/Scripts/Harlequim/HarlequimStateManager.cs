using UnityEngine;

public class HarlequimStateManager : BossStateManager
{
    void Start()
    {
        stateManager = new StateManager();
        stateManager.Start(new HarlequimIdleState(gameObject));
    }
}
