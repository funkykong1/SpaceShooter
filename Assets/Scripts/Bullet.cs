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

        Destroy(gameObject, 5f);
    }

    // Update is called once per frame


    void Update() {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyAI>(out EnemyAI _enemy))
        {
            Destroy(gameObject);
            _enemy.healthSystem.Damage(bulletDamage);
            Debug.Log("Hit" + " for " + bulletDamage + " damage!!!");

            if (_enemy.healthSystem.GetHealth() <= 0)
            {
                _enemy.Die();
            }
        }

    }
}

