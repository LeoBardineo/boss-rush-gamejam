using UnityEngine;

public class SetActiveTimer : MonoBehaviour
{
    public GameObject canva;
    public float currentTime = 0f;
    public float timer;

    void Start()
    {
        currentTime = 0f;
    }

	void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= timer)
        {
            canva.SetActive(true);
        }
	}
}
