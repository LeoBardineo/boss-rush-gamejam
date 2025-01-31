using System.Collections;
using UnityEngine;

public class OurosAntecipacao : MonoBehaviour
{
    [SerializeField]
    GameObject ourosProjetil;

    [SerializeField]
    float antecipationDurationOffset = 0f;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(WaitAntecipation(animator.GetCurrentAnimatorStateInfo(0).length + antecipationDurationOffset));
    }

    IEnumerator WaitAntecipation(float antecipationDuration)
    {
        animator.Play("OurosCartaAntecipacao");
        yield return new WaitForSeconds(antecipationDuration);
        Vector3 projetilPosition = transform.position + new Vector3(0, 0, transform.position.x * 0.01f + 2);
        GameObject projetil = Instantiate(ourosProjetil, projetilPosition, ourosProjetil.transform.rotation);
        projetil.transform.SetParent(transform, true);
        animator.Play("OurosAntecipacaoSaindo");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + 1f);
        Destroy(gameObject);
    }
}
