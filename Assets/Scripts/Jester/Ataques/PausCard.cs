using UnityEngine;

public class PausCard : MonoBehaviour
{
    public float cardHP;
    public PlayerController playerController;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TomarDano(float dano)
    {
        cardHP -= dano;
        if(cardHP <= 0)
        {
            DestroyCard();
        }
    }
    
    void DestroyCard()
    {
        PausSpawner.cardSpawned = false;
        ReverseControls();
        animator.Play("PausCartaAntecipacaoReverse");
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length + 0.25f);
    }
    
    public void ReverseControls()
    {
        if(PausSpawner.cardSpawned)
            animator.Play("PausCartaHitMe");
        playerController.speed *= -1;
        //playerController.gameObject.GetComponent<SpriteRenderer>().flipX = !PausSpawner.cardSpawned;
        playerController.transform.Rotate(0f,-180f,0f);
    }

    void MirrorCamera()
    {
        Camera.main.projectionMatrix *= Matrix4x4.Scale(new Vector3(-1, 1, 1));
    }
}