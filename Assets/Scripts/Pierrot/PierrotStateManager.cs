using UnityEngine;
using Unity.VisualScripting;

public class PierrotStateManager : BossStateManager
{
    void Start()
    {
        stateManager = new StateManager();
        stateManager.Start(new PierrotIdleState(gameObject));
    }
}
