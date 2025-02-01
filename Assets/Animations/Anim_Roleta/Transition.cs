using UnityEngine;

public class TransitionAnimator : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        Invoke("StartTransition",2.2f);
    }

    public void StartTransition()
    {
        animator.SetTrigger("StartTransition");
    }
}
