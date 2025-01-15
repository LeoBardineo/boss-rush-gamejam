using UnityEngine;

class PausCard : MonoBehaviour
{
    public float cardHP;
    public PlayerController playerController;

    void Start()
    {
        reverseControls();
    }

    public void TomarDano(float dano)
    {
        cardHP -= dano;
        if(cardHP <= 0)
        {
            DestroyCard();
        }
    }
    
    void DestroyCard()
    {
        reverseControls();
        PausSpawner.cardSpawned = false;
        Destroy(gameObject);
    }
    
    void reverseControls()
    {
        playerController.speed *= -1;
    }

    void mirrorCamera()
    {
        Camera.main.projectionMatrix *= Matrix4x4.Scale(new Vector3(-1, 1, 1));
    }
}