public class JesterStateManager : BossStateManager
{
    void Start()
    {
        stateManager = new StateManager();
        stateManager.Start(new JesterIdleState(gameObject));
    }
}