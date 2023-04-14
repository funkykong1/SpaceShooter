using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerLaserScript : MonoBehaviour
{
    public float speed = 7f;

    Rigidbody2D rb;

    public int bulletDamage = 34;

    //TODO: Replace bullet sprites

    
    // Start is called before the first frame update
    void Start()
    {
        //transform.right = FindClosest.Instance.dirToEnemy;
        rb = GetComponent<Rigidbody2D>();


        //rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    // Update is called once per frame


    void Update() {

    //move the thing up
    transform.Translate(Vector3.up * Time.deltaTime * speed);


    // fucks off bullet when it goes offscreen
    // prevents player from cheesing foes
    if (transform.position.y > 19)
        Destroy(gameObject);
    }
        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit the bad guy for " + bulletDamage + " damage!");
            Destroy(gameObject);
        }
        else if (other.CompareTag("LaserEnemy"))
        {
            Debug.Log("Crack shot bud. Enemy bullet gone");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
