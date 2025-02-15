using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    
    public GameObject bulletBad;
    private Animator anim;
    private EnemyMaster enemyMaster;
    public Transform enemyBarrel;
    public float firerate;

    void Awake()
    {
        //tell script which is what
        anim = GetComponent<Animator>();
        enemyMaster = GetComponentInParent<EnemyMaster>();
    }
    
    void Update()
    {

        //normalized time means value of 0.00-1.00 dictates anim length
        //if (enemyMaster.entering == false) 
        //{

            if(anim.GetCurrentAnimatorStateInfo(0).IsName("EnemyLaserFire") &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                anim.SetBool("firing", false);
                anim.speed = firerate;
            } 
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("EnemyLaserCharge") &&
                    anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                    {
                        anim.SetBool("firing", true);
                    }
        //}
    }
        
    void ShootLaser()
    {
        Instantiate(bulletBad, enemyBarrel.transform.position, bulletBad.transform.rotation);
    }
    
}

