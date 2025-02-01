using UnityEngine;

public class HarlequimStateManager : MonoBehaviour
{
    StateManager stateManager;
    public float idleDuration;

    void Start()
    {
        stateManager = new StateManager();
        stateManager.Start(new HarlequimIdleState(gameObject));
    }

    void Update()
    {
        stateManager.Update();
    }
}
