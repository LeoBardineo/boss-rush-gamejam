using UnityEngine;

public class EspadasAttack : MonoBehaviour
{
    [SerializeField]
    float speed = 20f;

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
            Debug.Log("dano dos soldados de espadas");
        }
    }

    // Quando os soldados saem da visão da câmera, ele se auto destrói
    void OnBecameInvisible()
    {
        Destroy(gameObject, 0.5f);
    }
}
