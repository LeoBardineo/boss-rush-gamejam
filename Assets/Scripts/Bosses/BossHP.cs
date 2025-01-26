using System.Collections;
using UnityEngine;

public class BossHP : MonoBehaviour
{

    public float maxHP, HP;
    private float originalColorTimer, timeOnRed=0.75f;
    private bool attacked = false;
    [SerializeField] SpriteRenderer SpriteRenderer;
    public bool fase2 = false, firstTimeFase2 = true;
    private UnityEngine.Color originalColor;
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

        maxHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (!attacked)
        {
            originalColor = SpriteRenderer.color;
        }
        //Script apenas por questões de debug abaixo
        if (attacked = true && originalColorTimer <= timeOnRed)
        {
            originalColorTimer += Time.deltaTime;
        }
        else
        {
            attacked = false;
            SpriteRenderer.color = originalColor;
            originalColorTimer=0;
        }

        if (HP<= (maxHP/2))
        {
            fase2 = true;
        }
    }


    public void Damage(float damage)
    {
        HP -= damage;
        //Script apenas por questões de debug abaixo
        SpriteRenderer.color = Color.magenta;
        attacked = true;
    }
}
