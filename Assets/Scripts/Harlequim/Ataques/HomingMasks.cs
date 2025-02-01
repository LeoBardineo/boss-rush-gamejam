using Unity.VisualScripting;
using UnityEngine;

public class HomingMasks : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Transform mouth;
    [SerializeField] private GameObject homingPrefab;
    private int missilesSpawned=1;
    private bool firstMissile=true;
    public static bool homingMasksAttacking;
    private float time, missilesDelay=2f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.M))
        {
            BeginHomingMasksAttack();
        }

        if (homingMasksAttacking)
        {
            if (missilesSpawned<=5)
            {
                if(firstMissile)
                {
                    Instantiate(homingPrefab,mouth.position,mouth.transform.rotation);
                    missilesSpawned+=1;
                    firstMissile = false;
                    return;
                }
                
                if(time<missilesDelay)
                {
                    time+= Time.deltaTime;
                }
                else
                {
                    missilesSpawned+=1;
                    Instantiate(homingPrefab,mouth.position,mouth.transform.rotation);
                    time=0;
                }
            }
            else
            {
                missilesSpawned=0;
                homingMasksAttacking = false;
            }
        }
    }

    public void BeginHomingMasksAttack()
    {
        homingMasksAttacking=true;
    }
}
