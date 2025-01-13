using System.Collections;
using UnityEngine;

public class BossHP : MonoBehaviour
{

    public float HP;
    private float originalColorTimer, timeOnRed=0.75f;
    private bool attacked = false;
    [SerializeField] SpriteRenderer SpriteRenderer;
    //Ideia: Variavel global para trackear quantos bosses já foram derrotados pra ajustar o HP de cada paz
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GlobalData.level == 0)
        {
            HP = 500;
        }
        if (GlobalData.level == 1)
        {
            HP = 550;
        }
        if (GlobalData.level == 2)
        {
            HP = 605;
        }
        if (GlobalData.level == 3)
        {
            HP = 665;
        }
        if (GlobalData.level == 4)
        {
            HP = 735;
        }
        Debug.Log("Boss HP:"+ HP);
    }

    // Update is called once per frame
    void Update()
    {
        //Script apenas por questões de debug abaixo
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
        //Script apenas por questões de debug abaixo
        SpriteRenderer.color = Color.red;
        attacked = true;
    }
}
