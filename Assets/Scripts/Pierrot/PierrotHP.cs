using System.Collections;
using UnityEngine;

public class PierrotHP : MonoBehaviour
{

    public float HP = 50;
    private float originalColorTimer, timeOnRed=0.75f;
    private bool attacked = false;
    [SerializeField] SpriteRenderer SpriteRenderer;
    //Ideia: Variavel global para trackear quantos bosses já foram derrotados pra ajustar o HP de cada paz
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attacked = true && originalColorTimer <= timeOnRed)
        {
            originalColorTimer += Time.deltaTime;
        }
        else
        {
            attacked = false;
            SpriteRenderer.color = Color.white;
            originalColorTimer=0;
        }
    }


    public void Damage(float damage)
    {
        HP -= damage;
        SpriteRenderer.color = Color.red;
        attacked = true;
    }
}
