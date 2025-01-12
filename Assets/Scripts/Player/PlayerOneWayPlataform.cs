using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerOneWayPlataform : MonoBehaviour
{
    private GameObject currentOneyWayPlatform;
    [SerializeField] private CapsuleCollider2D playerCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentOneyWayPlatform != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
                currentOneyWayPlatform = collision.gameObject;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneyWayPlatform = null;
        }        
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentOneyWayPlatform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.6f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }
}
