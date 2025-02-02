using UnityEngine;

public class HarlequimTakeDamage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float originalColorTimer, timeOnRed=2f;
    [SerializeField]
    private bool hand;
    [SerializeField]
    private bool attacked = false;
    [SerializeField] SpriteRenderer SpriteRenderer;
    private Color originalColor;
    //Ideia: Variavel global para trackear quantos bosses já foram derrotados pra ajustar o HP de cada paz
    [SerializeField] private HarlequimHPManager harlHPManager;

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
            originalColorTimer = 0;
        }

    }


    public void Damage(float damage)
    {
        attacked = true;
        Debug.Log("Dano");
        harlHPManager.Damage(damage);
    }

    private bool IsHand()
    {
        if(hand)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
