using System.Collections;
using UnityEngine;

public class PausCard : MonoBehaviour
{
    public float cardHP;
    public PlayerController playerController;
    public Animator animator;

    [SerializeField]
    float tempoDeAnimacaoOffset = 0.25f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TomarDano(float dano)
    {
        cardHP -= dano;
        if(cardHP <= 0)
        {
            StartCoroutine(DestroyCard());
        }
    }
    
    IEnumerator DestroyCard()
    {
        PausSpawner.cardSpawned = false;
        animator.Play("PausCartaAntecipacaoReverse");
        float tempoDeAnimacao = animator.GetCurrentAnimatorStateInfo(0).length + tempoDeAnimacaoOffset;
        yield return new WaitForSeconds(tempoDeAnimacao);
        Destroy(gameObject);
        ReverseControls();
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