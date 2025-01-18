using UnityEditor.UI;
using UnityEngine;

public class WaveBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject wavePrefab;
    [SerializeField]
    private Transform spawnPoint;
    private GameObject wave;
    private float waveSpeed = 5;
    private float timeToDestroy = 120;
    private float timePassed = 0;
    public static bool waveSpawned = false;

    // Update is called once per frame
    void Update()
    {
        if (waveSpawned)
        {
            moveWave();
        }
    }

    void moveWave()
    {
        if (timePassed >= timeToDestroy)
        {
            waveSpawned = false;
            Destroy(this.wave);
            timePassed = 0f;
        }
        else
        {
            rb.linearVelocity = new Vector2(-(waveSpeed * waveSpeed), rb.linearVelocity.y);
            timePassed += 0.1f;
        }
    }

    public void InstantiateWave()
    {
        wave = Instantiate(wavePrefab, spawnPoint.position, Quaternion.identity);
        rb = wave.GetComponent<Rigidbody2D>();
        waveSpawned = true;
        Debug.Log("ONDAAAAA PORRRRAA");
    }
}
