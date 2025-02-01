using UnityEngine;

public class CopasAttack : MonoBehaviour
{
    [SerializeField]
    float antecipationDurationOffset = 0f, attackDuration = 1f, damage = 1f;
    float antecipationDuration;
    float timeSinceStart = 0f;
    bool attacking = false, attacked = false;

    public Transform player;
    float raioDoCirculo;
    Animator animator;

    void Awake()
    {
        raioDoCirculo = GetComponent<CircleCollider2D>().radius * transform.localScale.x;
        animator = GetComponent<Animator>();
        antecipationDuration = animator.GetCurrentAnimatorStateInfo(0).length + antecipationDurationOffset;
        GetComponent<CircleCollider2D>().enabled = false;
    }

    void Update()
    {
        timeSinceStart += Time.deltaTime;

        if(timeSinceStart >= antecipationDuration && !attacking) {
            animator.Play("CopasBang");
            attacking = true;
            GetComponent<CircleCollider2D>().enabled = true;

            float distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
            if(distance <= raioDoCirculo)
                Attack(player.gameObject.GetComponent<PlayerHP>());

            Destroy(gameObject, attackDuration);
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (collision.GetComponent<PlayerHP>() != null)
            {
                PlayerHP playerHP = collision.GetComponent<PlayerHP>();
                if (!playerHP.invicible)
                {
                    Attack(playerHP);
                }
            }
        }
    }

    void Attack(PlayerHP playerHP)
    {
        if(!attacked && attacking)
        {
            playerHP.TakeDamage(damage);
            attacked = true;
        }
    }
}
