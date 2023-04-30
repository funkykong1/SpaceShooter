using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamWeld : MonoBehaviour
{
    public PlayerBeamScript beamScript;
    void Awake()
    {
        beamScript = GameObject.FindGameObjectWithTag("BeamGood").GetComponent<PlayerBeamScript>();
    }
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
        GameObject objectCollided = other.gameObject;  // Get a reference to the object hit
        Damageable dmgComponent = objectCollided.GetComponent<Damageable>();

        }
    }
}
