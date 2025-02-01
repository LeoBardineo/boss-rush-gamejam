using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GO_DestroyerClock : MonoBehaviour
{
    public float timer = 2f;
    public GameObject caralhaA4;

    void Start()
    {
        Destroy(caralhaA4,timer);
    }
}
