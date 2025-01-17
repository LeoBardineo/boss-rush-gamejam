using UnityEngine;

public class RageScreamState : IState
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 PushDirection;
    [SerializeField] private float ScreamStrenght=30;

    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public IState GetNext()
    {
        throw new System.NotImplementedException();
    }

    public void OnTriggerEnter(Collider other)
    {
        throw new System.NotImplementedException();
    }

    public void OnTriggerExit(Collider other)
    {
        throw new System.NotImplementedException();
    }

    public void OnTriggerStay(Collider other)
    {
        throw new System.NotImplementedException();
    }

    void Update()
    {
        rb.AddForce(PushDirection*ScreamStrenght);
    }

    void IState.Update()
    {
        Update();
    }
}
