using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Roleta : MonoBehaviour
{
    [SerializeField] float tempoDeGiro = 2.0f;
    [SerializeField] float minVInicial, maxVInicial;
    int escolha;
    bool girando = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            IniciarGiro();
        }
    }

    public void IniciarGiro()
    {
        if (!girando)
        {
            StartCoroutine(GirarRoleta());
        }
    }

    IEnumerator GirarRoleta()
    {
        girando = true;
        float tempoPassado = 0f;
        float velocidadeInicial = Random.Range(minVInicial, maxVInicial);
        float velocidadeFinal = 0f;

        while (tempoPassado < tempoDeGiro)
        {
            float progresso = tempoPassado / tempoDeGiro;
            float velocidadeAtual = Mathf.Lerp(velocidadeInicial, velocidadeFinal, Mathf.SmoothStep(0f, 1f, progresso));
            transform.Rotate(0f, 0f, velocidadeAtual * Time.deltaTime);
            tempoPassado += Time.deltaTime;
            yield return null;
        }

        
        float anguloFinal = transform.eulerAngles.z % 360;
        escolha = Escolher(anguloFinal);

        Debug.Log($"A roleta parou na escolha: {escolha}");
        girando = false;
    }

    int Escolher(float angulo)
    {
        if (angulo >= 0 && angulo < 90) return 1;
        if (angulo >= 90 && angulo < 180) return 2;
        if (angulo >= 180 && angulo < 270) return 3;
        return 4;
    }
}
