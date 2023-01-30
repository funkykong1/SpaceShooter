using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    
    public GameObject bulletBad;


    //bullets will phase through inactive enemies
    public bool enemyVisible;

    //enemy will move to assigned patrol point until true
    public bool enemyStopped = false;
    public float enemySpeed = 5f;

    //references 2 animator
    private Animator anim;
    public bool firing;

    //git lengths of animashion clips for instantaneous and incredible switching from one to nother
    //charging 0 firing 1
    public AnimationClip[] animations;


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
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= animations[0].length)
            {
                firing = false;
            } 
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("LaserCharging") &&
                    anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= animations[1].length)
                    {
                        firing = true;
                        Invoke("ShootLaser", 0.3f);
                    }
        }
    }
    
    void ShootLaser()
    {
        Vector3 laserBarrel = new Vector3(transform.position.x, transform.position.y - 1.7f, 0);
        Instantiate(bulletBad, laserBarrel, bulletBad.transform.rotation);
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

