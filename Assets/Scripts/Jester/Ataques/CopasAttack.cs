using Unity.VisualScripting;
using UnityEngine;

public class CopasAttack : MonoBehaviour
{
    [SerializeField]
    float antecipationDuration = 2f, attackDuration = 1f, offset = 1f;
    float timeSinceStart = 0f;
    bool attacking = false, attacked = false;

    public Transform player;
    SpriteRenderer sp;
    Color color;
    float raioDoCirculo;

    void Awake()
    {
        raioDoCirculo = GetComponent<CircleCollider2D>().radius * transform.localScale.x;
        GetComponent<CircleCollider2D>().enabled = false;
    }
    
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        color = sp.color;
        color.a = 0f;
        sp.color = color;
    }

    void Update()
    {
        timeSinceStart += Time.deltaTime;

        if(timeSinceStart < antecipationDuration)
        {
            color.a = timeSinceStart / (antecipationDuration + offset);
            sp.color = color;
        } else if (!attacking) {
            color = Color.red;
            sp.color = color;
            attacking = true;
            GetComponent<CircleCollider2D>().enabled = true;

            float distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
            if(distance <= raioDoCirculo)
                Attack();

            Destroy(gameObject, attackDuration);
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Attack();
        }
    }

    void Attack()
    {
        if(!attacked && attacking)
        {
            Debug.Log("dano de copas");
            attacked = true;
        }
    }
}
