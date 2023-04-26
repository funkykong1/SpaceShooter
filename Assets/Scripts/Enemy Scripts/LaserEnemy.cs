using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    
    public GameObject bulletBad;
    private Animator anim;


    //bullets will phase through inactive enemies
    private bool isVisible;

    public Transform enemyBarrel;

    void Awake()
    {
        //tell script which is what
        anim = GetComponent<Animator>();
    }
    
    void Update() {
        
        //fucking KILL yourself
        // if(firing)
        // anim.SetBool("firing", true);
        // else 
        // anim.SetBool("firing", false);
        
        if (transform.position.y < 17)
        {
            //start firing and become hittable
            isVisible = true;
        }


        //normalized time means value of 0.00-1.00 dictates anim length
        if (isVisible == true) {

            if(anim.GetCurrentAnimatorStateInfo(0).IsName("EnemyLaserFire") &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                anim.SetBool("firing", false);
            } 
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("EnemyLaserCharge") &&
                    anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                    {
                        anim.SetBool("firing", true);
                    }
        }
    }
    
    void ShootLaser()
    {
        Instantiate(bulletBad, enemyBarrel.transform.position, bulletBad.transform.rotation);
    }
    
    public void Die()
    {
        Destroy(gameObject);
       
        //FindObjectOfType<AudioManager>().Play("EnemyDeath");
    }
    
}

