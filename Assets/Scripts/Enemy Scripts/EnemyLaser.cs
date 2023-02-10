using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    
    public GameObject bulletBad;
    private Animator anim;


    //bullets will phase through inactive enemies
    public bool enemyVisible;


    //enemy will move to assigned patrol point until true
    public bool enemyStopped = false;
    public float enemySpeed = 5f;
    private float hp;

    //references 2 animator
    public bool firing;

    public Transform enemyBarrel;

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


        //normalized time means value of 0.00-1.00 dictates anim length
        if (enemyVisible == true) {

            if(anim.GetCurrentAnimatorStateInfo(0).IsName("LaserFiring") &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                firing = false;
            } 
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("LaserCharging") &&
                    anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                    {
                        firing = true;
                        Invoke("ShootLaser", 0.15f);
                    }
        }
    }
    
    void ShootLaser()
    {
        Instantiate(bulletBad, enemyBarrel.transform.position, bulletBad.transform.rotation);
    }

    public void MoveToPoint()
    {
        //idk add the patrol shit later lol
        transform.Translate(Vector3.down * Time.deltaTime * enemySpeed);
    }
    
    public void Die()
    {
        Destroy(gameObject);
        //FindObjectOfType<AudioManager>().Play("EnemyDeath");
    }
    
}

