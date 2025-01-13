using UnityEngine;

public class EspadasSpawner : MonoBehaviour
{
    public GameObject espadas;
    public Transform spawnArea;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            SpawnEspadas();
        }
    }

    void SpawnEspadas()
    {
        Vector3 spawnPosition = new Vector3(spawnArea.position.x, spawnArea.position.y, spawnArea.position.z);
        Instantiate(espadas, spawnPosition, espadas.transform.rotation);
    }
}
