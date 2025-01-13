using UnityEngine;

public class CopasSpawner : MonoBehaviour
{
    public GameObject copas;
    public Transform player;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)){
            SpawnCopas();
        }
    }

    void SpawnCopas()
    {
        copas.GetComponent<CopasAttack>().player = player;
        Vector3 spawnPosition = new Vector3(player.position.x, player.position.y, player.position.z);
        Instantiate(copas, spawnPosition, copas.transform.rotation);
    }
}
