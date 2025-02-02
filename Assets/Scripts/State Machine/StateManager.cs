using UnityEngine;

public class StateManager
{
    public IState currentState;
    bool isTransitioningState = false;

    public void Start(IState initialState)
    {
        currentState = initialState;
        currentState.Enter();
    }

    public void Update()
    {
        if(isTransitioningState) return;

        IState nextState = currentState.GetNext();

        if(nextState == null){
            currentState.Exit();
            return;
        }

        if(nextState.Equals(currentState)) {
            currentState.Update();
        } else {
            TransitionToState(nextState);
        }
    }

    public void TransitionToState(IState nextState) {
        isTransitioningState = true;
        currentState.Exit();
        
        currentState = nextState;

        currentState.Enter();
        isTransitioningState = false;
    }

    void OnTriggerEnter(Collider other){
        currentState.OnTriggerEnter(other);
    }

    void OnTriggerStay(Collider other){
        currentState.OnTriggerStay(other);
    }

    void OnTriggerExit(Collider other){
        currentState.OnTriggerExit(other);
    }
}