using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBulletScript : MonoBehaviour
{
    private float speed = 20f;
    private int droneBulletDamage = 15;


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
            Debug.Log("Taken a hit" + " for " + droneBulletDamage + " damage!!!");
            other.gameObject.GetComponent<PlayerHealth>().currHealth -= droneBulletDamage;
            Destroy(gameObject);
        } 
    }
}
