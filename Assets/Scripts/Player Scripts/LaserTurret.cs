using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : MonoBehaviour
{
    public Transform playerBarrel;
    //laser prefab
    public GameObject playerLaser;

    private Animator anim;

    //how many lazers play allowed to shoot?
    public int burstCount;

    void Start()
    {
        anim = GetComponent<Animator>();
        burstCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && firingReady())
        {
            anim.SetTrigger("firing");
        }


        if (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerLaserCharge"))
        {
            burstCount = 0;
            anim.SetInteger("burstCount", burstCount);
        }
    }


    //use animation events instead of manual timing
    void Shoot() 
    {
        Instantiate(playerLaser, playerBarrel.transform.position, playerLaser.transform.rotation);

        burstCount++;
        anim.SetInteger("burstCount", burstCount);
        
    }

    bool firingReady()
    {
        if((anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) && anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerLaserCharge") || (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerLaserStart")
         && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1))
        {
            return true;
        } else {
            return false;
        }
    }
}

