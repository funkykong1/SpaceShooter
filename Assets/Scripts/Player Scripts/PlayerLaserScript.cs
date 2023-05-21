using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerLaserScript : MonoBehaviour
{
    public float speed;
    public float bulletDamage;
    public GameObject laserExplosion;

    void Update()
    {

    //move the thing up
    transform.Translate(Vector3.up * Time.deltaTime * speed);

    if (transform.position.y > 15)
        Destroy(gameObject);
    }


        void OnTriggerEnter2D(Collider2D other)
    {

        GameObject objectCollided = other.gameObject;
        Damageable dmgComponent = objectCollided.GetComponent<Damageable>();

        if (dmgComponent)
        {
            Debug.Log("Hit the bad guy for " + bulletDamage + " damage!");

            dmgComponent.doDamage(bulletDamage); // Here you damage the object, without knowing which type it is

            Instantiate(laserExplosion, transform.position, transform.rotation);

            Destroy(gameObject);
        }
        
        else if (other.CompareTag("LaserBad"))
        {
            Debug.Log("Crack shot bud. Enemy bullet gone");

            Instantiate(laserExplosion, transform.position, transform.rotation);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.CompareTag("BeamBad"))
        {
            Instantiate(laserExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
