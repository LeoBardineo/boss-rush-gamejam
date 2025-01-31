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
    [SerializeField]
    private float waveSpeed = 5;
    [SerializeField]
    private float timeToDestroy = 1;
    private float timePassed = 0;
    public static bool waveSpawned = false;
    [SerializeField]
    private AudioSource somDeOnda;


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
            timePassed += Time.deltaTime;
        }
    }

    public void InstantiateWave()
    {
        somDeOnda.Play();
        wave = Instantiate(wavePrefab, spawnPoint.position, Quaternion.identity);
        rb = wave.GetComponent<Rigidbody2D>();
        waveSpawned = true;

    }
}
