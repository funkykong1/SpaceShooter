using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    
    public GameObject bulletBad;
    public Transform bulletPos;


    //bullets will phase through inactive enemies
    public bool enemyVisible = false;

    //enemy will move to assigned patrol point until true
    public bool enemyStopped = false;
    public float enemySpeed = 5f;

    //references 2 animator
    private Animator anim;
    public bool firing = false;

    //holds the pos of assigned patrol point
    private Vector2 destination;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        healthSystem = new HealthSystem(100);

        rb = GetComponent<Rigidbody2D>();

    }
    void Update() {
        //play firing lazer animation if firing true
        if (firing)
        anim.SetBool("firing", true);
        else
        anim.Setbool("firing", false);

        if (transform.position.y < 17)
        {
            //start firing and become hittable
            enemyVisible = true;
        }


        if (enemyStopped = false;)
        {
        //go down when enemyStopped false
        MoveToPoint();
        }
        

        if (enemyVisible == true) {

            //enemy shooting
            if (enemyLaserTimer > 0) {
              enemyLaserTimer--; 
            } else {
                enemyLaserCooldown = false;
            } 

            if (enemyLaserCooldown == false) {
            //laukaisee yhden oranssia laaseria vihollisesta
            StartCoroutine(ShootLaser());
        }
        }
    }




        IEnumerator ShootLaser() {

        //enemylasertimer is how often the thing fires
         for (int i = 0; i < 1; i++) {
            enemyLaserCooldown = true;
                firing = true;
                Instantiate(bulletBad, transform.position, bulletBad.transform.rotation);

                yield return new WaitUntil(() =>   enemyLaserTimer <= 0);

            }
            //myöhemmin vvvv, ehkä
             //FindObjectOfType<AudioManager>().Play("Pew");
            enemyLaserTimer = 500;
        enemyLaserCooldown = true;


    }


    public void MoveToPoint()
    {
        while(!enemyStopped)
        transform.Translate(Vector3.down * Time.deltaTime * enemySpeed);
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.CompareTag("Bullet"))
        {
            healthSystem.Damage(50);
            // Debug.Log("EnemyHP: " + healthSystem.GetHealthPercent());
            print("Hit");

            if (healthSystem.GetHealth() <= 0)
            {
                Die();
            }
        }*/
        if (collision.CompareTag("Player"))
        {
            Die();
        }

    }
    
    public void Die()
    {
        Destroy(gameObject);
        //FindObjectOfType<AudioManager>().Play("EnemyDeath");
    }
    
}
