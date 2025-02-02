using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMasksBehaviour : BossDMG
{
    private GameObject target;
    [SerializeField]
    private float speed = 2f, rotateSpeed= 200f, timeToExplode=5f,time=0f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    public bool srDead, deathByNotColliding;
    [SerializeField] private AudioSource sound,tracking;

    private bool somethingHit=false;
    protected override void  Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!somethingHit && !deathByNotColliding)
        {
            Vector2 direction = (Vector2)target.transform.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed;
            rb.linearVelocity = transform.up * speed;
        }
        else
        {
            rb.angularVelocity=0;
            rb.linearVelocity=Vector2.zero;
        }
    }

    void Update()
    {
        if (time <= timeToExplode)
        {
            time += Time.deltaTime;
        }
        else
        {
            deathByNotColliding = true;
            anim.Play("missile-explosion");
            sound.Play();
            rb.angularVelocity=0;
            rb.linearVelocity=Vector2.zero;
        }
        if (srDead)
        {
            Destroy(gameObject);
        }
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.CompareTag("OneWayPlatform"))
        {
            somethingHit=true;
            sound.Play();
            anim.Play("missile-explosion");
        }
        if (collision.CompareTag("Player"))
        {
            somethingHit=true;
            sound.Play();
            anim.Play("missile-explosion");
        }
    }
}
