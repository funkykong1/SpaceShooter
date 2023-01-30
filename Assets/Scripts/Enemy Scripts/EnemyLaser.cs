using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    
    public GameObject bulletBad;
    public Transform bulletPos;


    //bullets will phase through inactive enemies
    public bool enemyVisible;

    //enemy will move to assigned patrol point until true
    public bool enemyStopped = false;
    public float enemySpeed = 5f;

    //references 2 animator
    private Animator anim;
    public bool firing;

    //git lengths of animashion clips for instantaneous and incredible switching from one to nother

    public Animation laserFiring;
    public Animation laserCharging;
    
    float firingLength;
    float chargingLength;

    //holds the pos of assigned patrol point
    private Vector2 destination;


    void Awake()
    {
        //tell script which is what
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        //start of round enemy not visible
        enemyVisible = false;

    }
    void Update() {
        //fucking KILL yourself
        if(firing)
        anim.SetBool("firing", true);
        else 
        anim.SetBool("firing", false);
        

        if (transform.position.y < 17)
        {
            //start firing and become hittable
            enemyVisible = true;
        }


        if (enemyStopped == false)
        {
        //go down when enemyStopped false
        //MoveToPoint();
        }
        

        if (enemyVisible == true) {

            if(anim.GetCurrentAnimatorStateInfo(0).IsName("LaserFiring") &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f)
            {
                firing = false;
            } 
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("LaserCharging") &&
                    anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.5f)
                    {
                        firing = true;
                        Invoke("ShootLaser", 0.2f);
                    }
        }
    }
    
    void ShootLaser()
    {
        Instantiate(bulletBad, transform.position, bulletBad.transform.rotation);
    }






    public void MoveToPoint()
    {
        //idk add the patrol shit later lol
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

