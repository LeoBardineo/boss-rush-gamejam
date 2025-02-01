using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject);
    }
}
