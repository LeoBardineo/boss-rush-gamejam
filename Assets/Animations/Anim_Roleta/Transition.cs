using UnityEngine;

public class TransitionAnimator : MonoBehaviour
{
    private Animator animator;
    public float time=2.2f;

    void Start()
    {
        animator = GetComponent<Animator>();
        Invoke("StartTransition",time);
    }

    public void StartTransition()
    {
        animator.SetTrigger("StartTransition");
    }
}
