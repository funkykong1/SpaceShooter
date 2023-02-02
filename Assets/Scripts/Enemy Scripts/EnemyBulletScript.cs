using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBulletScript : MonoBehaviour
{
    public float speed = 10f;
    public float enemyBulletDamage = 25;


    // Start is called before the first frame update
    void Start()
    {        
        //fucking divide it into 2 cuz enemy laser wants to shoot 2 of them for no reason
        enemyBulletDamage = enemyBulletDamage / 2;
    }

    // Update is called once per frame
    void Update()
    {

    if (transform.position.y < -25)
    {
        Destroy(gameObject); 
    }

        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Taken a hit" + " for " + enemyBulletDamage * 2 + " damage!!!");
            other.gameObject.GetComponent<PlayerHealth>().health -= enemyBulletDamage;
            Destroy(gameObject);
        }

    }
}


