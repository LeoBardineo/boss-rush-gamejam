using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerClock : MonoBehaviour
{
    public float timer = 2f;

    void Start()
    {
        Destroy(this,timer);
    }
}
