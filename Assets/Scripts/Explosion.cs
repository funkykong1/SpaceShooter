using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360));
    }

    public void End()
    {
        Destroy(gameObject);
    }

}
