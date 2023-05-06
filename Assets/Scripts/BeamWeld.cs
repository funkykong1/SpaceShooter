using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamWeld : MonoBehaviour
{
    void Awake()
    {
        int rand = Random.Range(0, 1);
        if(rand == 1)
            transform.rotation = Quaternion.Euler(0, 0, 180);
    }
    void End()
    {
        Destroy(gameObject);
    }
}
