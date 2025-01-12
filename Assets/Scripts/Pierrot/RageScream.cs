using UnityEngine;

public class RageScream : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    //Precisa colocar o número -1 por exemplo pra empurrar o player pra esquerda no inspector do unity.
    [SerializeField] private Vector2 PushDirection;
    [SerializeField] private float ScreamStrenght=30;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(PushDirection*ScreamStrenght);
    }
}
