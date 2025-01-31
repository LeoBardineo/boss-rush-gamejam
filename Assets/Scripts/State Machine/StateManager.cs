using UnityEngine;
using System;
using UnityEditor.Rendering;
using System.Collections.Generic;

public class StateManager
{
    IState currentState;
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

        if(nextState == null)
            currentState.Exit();

        if(nextState.Equals(currentState)) {
            currentState.Update();
        } else {
            TransitionToState(nextState);
        }
    }

    void TransitionToState(IState nextState) {
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