using UnityEngine;

public class OurosAttack : MonoBehaviour
{
    public int damage = 1;
    
    [SerializeField]
    float quebrandoDurationOffset = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerHP>() != null)
            {
                PlayerHP playerHP = collision.GetComponent<PlayerHP>();
                if (!playerHP.invicible)
                {
                    playerHP.TakeDamage(damage);
                }
            }
            DestroyCarta();
        }

        if(collision.CompareTag("Ground"))
        {
            DestroyCarta();
        }
    }

    void DestroyCarta()
    {
        GetComponent<CircleCollider2D>().enabled = false;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.linearVelocity = new Vector2(0, 0);

        Animator animator = GetComponent<Animator>();
        animator.Play("OurosProjetilQuebrando");

        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length + quebrandoDurationOffset);
    }
}
