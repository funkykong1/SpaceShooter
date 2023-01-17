using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    public float speed = 7f;

    Rigidbody2D rb;
    

    public int bulletDamage = 34;

    
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
}
