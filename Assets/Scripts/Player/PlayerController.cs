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
    //↓↓ Tratamento de jogador para direita ou para esquerda ↓↓
    // Basicamente só to checando se ele ta olhando pra direita. Se não está, tá olhando pra esquerda. Pegando a ultima direção que ele ta olhando determina já o dash certo
    public bool facingRight;
    public bool idle;

    //↑↑ Tratamento de jogador para direita ou para esquerda ↑↑
    
    //↓↓ Dash ↓↓
    private bool canDash = true;
    private bool isDashing = false;
    private float dashingPower = 50f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private TrailRenderer tr;

    //↑↑ Dash ↑↑
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
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
        CheckLookDirection(moveInput);
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

    //Checa se o player ta olhando pra direita, pra esquerda ou ta idle. O idle não ta sendo usado ainda mas eu coloquei porque imagino que a gente vai usar futuramente pra fatores de animação.
    void CheckLookDirection(float moveInput)
    {
        if (moveInput > 0)
        {
            idle = false;
            facingRight = true;
        }
        else if (moveInput < 0)
        {
            idle = false;
            facingRight = false;
        }
        else
        {
            idle = true;
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
        if (facingRight)
        {
            rb.linearVelocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        }
        else
        {
            rb.linearVelocity = new Vector2(-transform.localScale.x * dashingPower, 0f);    
        }
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
