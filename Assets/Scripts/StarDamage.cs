using UnityEngine;

public class StarDamage : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("dano da estrela");
            Destroy(gameObject);
        }

        if(collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
