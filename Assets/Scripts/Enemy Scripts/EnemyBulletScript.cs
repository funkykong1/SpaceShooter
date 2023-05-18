using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBulletScript : MonoBehaviour
{
    public float speed = 10f;
    public int enemyBulletDamage = 25;

    public GameObject laserExplosion;


    // Start is called before the first frame update
    void Start()
    {        
        //fucking divide it into 2 cuz enemy laser wants to shoot 2 of them for no reason
        //no longer does this? why
        //enemyBulletDamage = enemyBulletDamage / 2;
    }

    // Update is called once per frame
    void Update()
    {

    if (transform.position.y < -15)
        Destroy(gameObject); 
    

        transform.Translate(Vector3.up * Time.deltaTime * speed);
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
    }
}


