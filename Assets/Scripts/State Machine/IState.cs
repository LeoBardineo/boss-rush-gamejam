using UnityEngine;
using System;

public interface IState
{
    void Enter();
    void Exit();
    void Update();
    IState GetNext();
    void OnTriggerEnter(Collider other);
    void OnTriggerStay(Collider other);
    void OnTriggerExit(Collider other);
}