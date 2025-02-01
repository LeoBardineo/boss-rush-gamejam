using UnityEngine;

public class ForcePlayAnimation : MonoBehaviour
{
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log("anima carai");
        animator.Play("PauseIN");
    }
}
