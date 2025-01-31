using UnityEngine;
using Unity.VisualScripting;

public class PierrotStateManager : MonoBehaviour
{
    StateManager stateManager;
    public float idleDuration;

    public IState lastUsedAttack;

    void Start()
    {
        stateManager = new StateManager();
        stateManager.Start(new PierrotIdleState(gameObject));
    }

    void Update()
    {
        stateManager.Update();
    }
}
