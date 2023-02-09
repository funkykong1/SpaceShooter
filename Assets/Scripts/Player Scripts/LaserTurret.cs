using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : MonoBehaviour
{
    public Transform playerBarrel;
    public GameObject playerLaser;

    private Animator anim;
    
    public bool firing;
    public int burstCount;

    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
        firing = false;
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
        }

        Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }


    void Shoot() 
    {
        Instantiate(playerLaser, playerBarrel.transform.position, playerLaser.transform.rotation);

        burstCount++;
        anim.SetInteger("burstCount", burstCount);
        
    }
    bool firingReady()
    {
        if((anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) && anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerLaserCharge") || (anim.GetCurrentAnimatorStateInfo(0).IsName("StartCharge")
         && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1))
        {
            return true;
        } else {
            return false;
        }
    }
}

