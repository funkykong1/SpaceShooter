using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBullet : MonoBehaviour
{

    [SerializeField]
    private float speed = 10f;

    Rigidbody2D rb;


    public int enemyBulletDamage = 25;

    // Start is called before the first frame update
    void Start()
    {        
        rb = GetComponent<Rigidbody2D>();

        Destroy(gameObject, 5f);
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
            Destroy(gameObject);
            //player.healthSystem.Damage(enemyBulletDamage);
            Debug.Log("Taken a hit" + " for " + enemyBulletDamage + " damage!!!");

            //if (player.healthSystem.GetHealth() <= 0)
            {
              //  Destroy(player);
            }
        }

    }
}


