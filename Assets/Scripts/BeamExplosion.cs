using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamExplosion : MonoBehaviour
{
    [HideInInspector]
    public float explosionDMG;

    public void End()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        GameObject objectCollided = other.gameObject;  // Get a reference to the object hit
        Damageable dmgComponent = objectCollided.GetComponent<Damageable>();

        if (dmgComponent)
        {
            dmgComponent.doDamage(explosionDMG);
            //Instantiate(laserExplosion, transform.position, transform.rotation);

        }
    }
}
