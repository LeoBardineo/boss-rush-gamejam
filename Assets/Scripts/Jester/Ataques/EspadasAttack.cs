using UnityEngine;

public class EspadasAttack : MonoBehaviour
{
    [SerializeField]
    float speed = 20f;

    [SerializeField]
    int damage = 1;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
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
                    playerHP.TakeDamage(damage);
                }
            }
        }
    }

    // Quando os soldados saem da visão da câmera, ele se auto destrói
    void OnBecameInvisible()
    {
        Destroy(gameObject.transform.parent.gameObject, 0.5f);
    }
}
