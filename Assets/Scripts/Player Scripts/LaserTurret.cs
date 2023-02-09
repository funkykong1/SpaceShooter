using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : MonoBehaviour
{
    public Transform playerBarrel;
    public GameObject playerLaser;

    private Animator anim;

    public bool firing;
    private bool done;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        firing = false;
    }

    // Update is called once per frame
    void Update()
    {        
        if(firing)
        anim.SetBool("firing", true);
        else 
        anim.SetBool("firing", false);

        if (Input.GetKeyDown(KeyCode.E) && (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerLaserCharge") &&
                                            anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1))
        {
            ShootBurst();
        }
    }
    IEnumerator ShootBurst()
    {
        firing = true;
        for (int i = 0; i < 3; i++) 
        {
            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            anim.Play("PlayerLaserFire");
            Invoke("FireLaser", 0.2f);
            
        }
        yield return firing = false;
    }
    private void FireLaser()
    {
        Instantiate(playerLaser, playerBarrel.transform.position, playerLaser.transform.rotation);
    }
    void Animate()
    {
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerLaserFire") &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                firing = false;
            } 
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerLaserCharging") &&
                    anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                    {
                        firing = true;
                        Invoke("ShootLaser", 0.3f);
                    }
    }
}
