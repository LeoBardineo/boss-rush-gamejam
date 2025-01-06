using Unity.VisualScripting;
using UnityEngine;

public class TesteStateManager : MonoBehaviour
{
    StateManager stateManager;

    void Start()
    {
        stateManager = new StateManager();
        stateManager.Start(new IdleState());
    }

    void Update()
    {
        stateManager.Update();
    }
}