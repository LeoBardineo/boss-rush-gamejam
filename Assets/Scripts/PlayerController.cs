using System.Collections;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    Rigidbody2D rb;
    bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    // Dash ↓↓↓↓↓↓ 
    private bool canDash = true;
    private bool isDashing = false;
    private float dashingPower = 50f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private TrailRenderer tr;

    // Dash ↑↑↑↑↑↑
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        DashLock();
        Dash();
        if (isDashing == false)
        {
            Move();
            Jump();
        }

    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal"); // "A/D" ou "Setas" padrão
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
        print(rb.linearVelocity);
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = isGrounded ? Color.blue : Color.red; // Escolha a cor do Gizmo
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius); // Desenha o círculo
        }
    }

    //Lida com o input do Dash. Posto aqui pra ficar mais organizado
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(DashRT());
        }
    }

    //Para prevenir o player de se mexer, pular ou algo do tipo enquanto dá dash.
    void DashLock()
    {
        if (isDashing)
        {
            return;
        }
    }

    //Rotina que trata o efeito do dash
    private IEnumerator DashRT()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
