using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBulletScript : MonoBehaviour
{
    private float speed = 20f;
    public int enemyBulletDamage = 15;


    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -25)
            Destroy(gameObject); 
        
            transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Taken a hit" + " for " + enemyBulletDamage + " damage!!!");
            other.gameObject.GetComponent<PlayerHealth>().currHealth -= enemyBulletDamage;
            Destroy(gameObject);
        } 
    }
}
