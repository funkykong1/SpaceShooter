using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneTurret : MonoBehaviour
{
    //copypasted from the player one

    //where the bullet comes from
    public Transform droneBarrel;
    //laser prefab
    public GameObject droneLaser;

    //fuck this one
    private Animator anim;

    //2
    public int burstCount;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        burstCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (firingReady())
        {
            anim.SetTrigger("firing");
        }


        if (anim.GetCurrentAnimatorStateInfo(0).IsName("DroneGunCharging"))
        {
            burstCount = 0;
            anim.SetInteger("burstCount", burstCount);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("DroneGunFiring") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 2 && burstCount == 2)
        {
            anim.SetTrigger("reload");
        }

        //prints animator state -> 1 = 100%
        //Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }


    //use animation events instead of manual timing!
    void Shoot() 
    {
        Instantiate(droneLaser, droneBarrel.transform.position, droneLaser.transform.rotation);

        burstCount++;
        anim.SetInteger("burstCount", burstCount);
        
    }

    //single bool function to house the horrible if statement
    bool firingReady()
    {
        if((anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) && anim.GetCurrentAnimatorStateInfo(0).IsName("DroneGunCharging"))
        {
            return true;
        } else {
            return false;
        }
    }
}

