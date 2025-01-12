using System.Collections;
using UnityEngine;

public class PierrotHP : MonoBehaviour
{

    public float HP = 50;
    [SerializeField] SpriteRenderer SpriteRenderer;
    //Ideia: Variavel global para trackear quantos bosses já foram derrotados pra ajustar o HP de cada paz
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Damage(float damage)
    {
        HP -= damage;
        SpriteRenderer.color = Color.red;
        float time = 0;
        while (time <= 40404f)
        {
            time += Time.deltaTime;
            Debug.Log("Tempo passando");
        }
        time=0;
        SpriteRenderer.color = Color.white;

    }
}
