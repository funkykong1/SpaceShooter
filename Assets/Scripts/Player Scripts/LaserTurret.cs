using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : MonoBehaviour
{
    public Transform playerBarrel;
    public GameObject playerLaser;

    private Animator anim;
    private Animation clip;
    public bool firing;
    public int loops;
    private bool Crunning;

    // Start is called before the first frame update
    void Start()
    {
        clip = GetComponent<Animation>();
        anim = GetComponent<Animator>();
        firing = false;
        Crunning = false;
        loops = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerLaserCharge"))
        {
            loops = 0;
            Crunning = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(playerLaser, playerBarrel.transform.position, playerLaser.transform.rotation);
        }

        Debug.Log(loops);
        anim.SetInteger("loops", loops);

        if (Input.GetKeyDown(KeyCode.E) && (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerLaserCharge") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1))
        {
            anim.SetTrigger("firing");
            StartCoroutine(Shoot());
        }
    }


    IEnumerator Shoot() 
    {
        Crunning = true;
        for (int i = 0; i < 3; i++)
        {
        Instantiate(playerLaser, playerBarrel.transform.position, playerLaser.transform.rotation);
        loops++;
        yield return new WaitWhile(() => anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= loops);
        }
    }
}

