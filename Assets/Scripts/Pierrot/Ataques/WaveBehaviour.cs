using UnityEditor.UI;
using UnityEngine;

public class WaveBehaviour : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    private float waveSpeed = 5;
    private float timeToDestroy = 120;
    private float timePassed = 0;

    // Update is called once per frame
    void Update()
    {
        moveWave();
    }

    void moveWave()
    {
        rb.linearVelocity = new Vector2(-(waveSpeed * waveSpeed), rb.linearVelocity.y);
        timePassed += 0.1f;
        if (timePassed >= timeToDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("dano da wave");
        }
    }
}
