using UnityEngine;
using UnityEditor.UI;

public class WaveState : IState
{

    float attackDuration;
    float timeSinceStart= 0f;
    GameObject bossGameObject;
    SpriteRenderer sp;
    WaveBehaviour wave;

    public WaveState(GameObject bossGameObject)
    {
        this.bossGameObject = bossGameObject;
        sp = bossGameObject.GetComponent<SpriteRenderer>();
        wave = bossGameObject.GetComponent<WaveBehaviour>();
    }
    public void Enter()
    {
        // inicia alguma animação do ataque começando
        Debug.Log("Entrou em waves");
        sp.color = Color.blue;
    }

    public void Exit()
    {
        Debug.Log("Saiu de waves");
        sp.color = Color.white;
    }

    public IState GetNext()
    {
        throw new System.NotImplementedException();
    }

    public void OnTriggerEnter(Collider other)
    {
        throw new System.NotImplementedException();
    }

    public void OnTriggerExit(Collider other)
    {
        throw new System.NotImplementedException();
    }

    public void OnTriggerStay(Collider other)
    {
        throw new System.NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceStart += Time.deltaTime;
        moveWave();
    }

    //---||||||Interface acima---||||||
        [SerializeField]
    private Rigidbody2D rb;
    private float waveSpeed = 5;
    private float timeToDestroy = 120;
    private float timePassed = 0;

    // Update is called once per frame

    void moveWave()
    {
        rb.linearVelocity = new Vector2(-(waveSpeed * waveSpeed), rb.linearVelocity.y);
        timePassed += 0.1f;
        if (timePassed >= timeToDestroy)
        {
            // Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("dano da wave");
        }
    }

    void IState.Update()
    {
        Update();
    }
}
