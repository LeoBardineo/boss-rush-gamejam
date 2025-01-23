using UnityEngine;

public class RageScream : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    //Precisa colocar o número -1 por exemplo pra empurrar o player pra esquerda no inspector do unity.
    [SerializeField] private Vector2 PushDirection;
    [SerializeField] private float ScreamStrenght=30;
    [SerializeField] private GameObject screamGO;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float attackDuration = 4f;
    private float time;
    public static bool rageScreamingOn;


    // Update is called once per frame
    void Update()
    {
        if (rageScreamingOn)
        {
            rb.AddForce(PushDirection*ScreamStrenght);
            time += Time.deltaTime;
            screamGO.SetActive(true);
            if (time >= attackDuration)
            {
                rageScreamingOn = false;
                time=0f;
                screamGO.SetActive(false);
            }
        }
    }

    public void RageScreamOn()
    {
        rageScreamingOn = true;
    }
}
