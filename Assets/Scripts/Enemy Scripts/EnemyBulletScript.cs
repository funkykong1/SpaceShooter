using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBulletScript : MonoBehaviour
{
    public float speed;     //set in inspector
    public int enemyBulletDamage;

    public GameObject laserExplosion;

    // Update is called once per frame
    void Update()
    {
    transform.Translate(Vector3.up * Time.deltaTime * speed);

    if (transform.position.y < -15 || transform.position.x > 15 || transform.position.x < -15)
        Destroy(gameObject); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Taken a hit" + " for " + enemyBulletDamage + " damage!!!");
            other.gameObject.GetComponent<PlayerHealth>().currHealth -= enemyBulletDamage;
            Instantiate(laserExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        } 
        else if (other.CompareTag("BeamGood"))
        {
            Instantiate(laserExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}


