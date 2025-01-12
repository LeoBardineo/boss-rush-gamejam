using UnityEngine;

public class PausAttack : MonoBehaviour
{
    public PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            reverseControls();
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            mirrorCamera();
        }
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
