using System.Collections;
using System.Threading;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public bool isGrounded;
    Rigidbody2D rb;
    public Animator animator;

    public bool exibeGroundCheck = false;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    //↓↓ Tratamento de jogador para direita ou para esquerda ↓↓
    // Basicamente só to checando se ele ta olhando pra direita. Se não está, tá olhando pra esquerda. Pegando a ultima direção que ele ta olhando determina já o dash certo
    public bool facingRight = true;
    public bool idle = true;
    public bool powerInCooldown = false, potionInCooldown = false;

    //↑↑ Tratamento de jogador para direita ou para esquerda ↑↑
    
    //↓↓ Dash ↓↓
    public float dashingPower = 50f;
    public float dashingTime = 0.08f;
    public float dashingCooldown = 1f;
    private bool canDash = true;
    private bool movimentLocked = false;
    private bool flipedToRight = true, flipedToLeft = false;

    public Weapon equipedWeapon;
    public Power equipedPower;

    [SerializeField]
    Potion equipedPotion;

    [SerializeField] private TrailRenderer tr;

    //↑↑ Dash ↑↑
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        facingRight = true;

        if(equipedWeapon == null)
        {
            equipedWeapon = equipFirstWeapon();
        }

        if(equipedPower == null)
        {
            equipedPower = equipFirstPower();
        }

        if(equipedPotion == null)
        {
            equipedPotion = equipFirstPotion();
        }

        speed *= GlobalData.playerData["Agilidade"][GlobalData.level];
    }

    void Update()
    {
        if(PlayerHP.dead || equipedWeapon.attacking) return;
        
        Dash();
        if (!movimentLocked)
        {
            Move();
            Jump();
            DoPower();
            DoPotion();
            Animate();
        }

    }

    void Animate()
    {
        if(equipedPower.isUsingPower) return;
        
        if(isGrounded)
        {
            if(idle)
            {
                animator.Play("Idle");
            }
            else
            {
                animator.Play("Walk");
            }
        } else if(!isGrounded && rb.linearVelocity.y < 0) {
            animator.Play("Fall");
        } else {
            animator.Play("Jump");
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

    void DoPower()
    {
        if(Input.GetKeyDown(GlobalData.powerButton) && !powerInCooldown)
        {
            equipedPower.UsePower();
        }
    }

    void DoPotion()
    {
        if(Input.GetKeyDown(GlobalData.potionButton) && !potionInCooldown)
        {
            equipedPotion.UsePotion();
        }
    }

    void OnDrawGizmos()
    {
        if (groundCheck != null && exibeGroundCheck)
        {
            Gizmos.color = isGrounded ? Color.blue : Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    // Checa se o player ta olhando pra direita, pra esquerda ou ta idle. O idle não ta sendo usado ainda mas eu coloquei porque imagino que a gente vai usar futuramente pra fatores de animação.
    void CheckLookDirection(float moveInput)
    {
        if (moveInput > 0) 
        {
            idle = false;
            facingRight = true;
            if (!flipedToRight)
            {
                transform.Rotate(0f,-180f,0f);
                flipedToRight = true;
                flipedToLeft = false;
            }
        } else if (moveInput < 0) {
            idle = false;
            facingRight = false;
            if(!flipedToLeft)
            {
                transform.Rotate(0f,-180f,0f);
                flipedToRight = false;
                flipedToLeft = true;
            }
        } else {
            idle = true;
        }
    }

    // Lida com o input do Dash
    void Dash()
    {
        if (Input.GetKeyDown(GlobalData.dashButton) && canDash && !movimentLocked)
        {
            StartCoroutine(DashRT());
        }
    }

    // Rotina que trata o efeito do dash
    private IEnumerator DashRT()
    {
        animator.Play("Dash");
        canDash = false;
        movimentLocked = true;
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
        animator.Play("Idle");
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        movimentLocked = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    // Não permite o personagem se mexer e zera sua velocidade
    public void LockMovement()
    {
        // animator.Play("Idle");
        movimentLocked = true;
        rb.linearVelocity = new Vector2(0f, 0f);
    }

    public void UnlockMovement()
    {
        movimentLocked = false;
    }

    Weapon equipFirstWeapon()
    {
        Weapon[] weapons = GetComponents<Weapon>();
        foreach (Weapon weapon in weapons)
        {
            if(weapon.enabled){
                return weapon;
            }
        }
        return null;
    }

    Power equipFirstPower()
    {
        Power[] powers = GetComponents<Power>();
        foreach (Power power in powers)
        {
            if(power.enabled){
                return power;
            }
        }
        return null;
    }

    Potion equipFirstPotion()
    {
        Potion[] potions = GetComponents<Potion>();
        foreach (Potion potion in potions)
        {
            if(potion.enabled){
                return potion;
            }
        }
        return null;
    }

    public float GetPowerCooldownPercentage()
    {
        return Mathf.Clamp01(equipedPower.cooldownRemaining / equipedPower.cooldownTime);
    }

    public float GetPotionCooldownPercentage()
    {
        return Mathf.Clamp01(equipedPotion.cooldownRemaining / equipedPotion.cooldownTime);
    }
}
