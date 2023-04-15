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


    //enemy will move to assigned patrol point until true
    public float enemySpeed = 5f;
    private float health;

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
        //isVisible = false;
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
            isVisible = true;
        }


        //normalized time means value of 0.00-1.00 dictates anim length
        if (isVisible == true) {

            if(anim.GetCurrentAnimatorStateInfo(0).IsName("EnemyLaserFire") &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                firing = false;
            } 
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("EnemyLaserCharge") &&
                    anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                    {
                        firing = true;
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

