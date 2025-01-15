using Unity.VisualScripting;
using UnityEngine;

public class JesterStateManager : MonoBehaviour
{
    StateManager stateManager;
    public float idleDuration;

    void Start()
    {
        stateManager = new StateManager();
        stateManager.Start(new JesterIdleState(gameObject));
    }

    void Update()
    {
        stateManager.Update();
    }
}