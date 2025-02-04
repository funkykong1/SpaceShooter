using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneTurret : MonoBehaviour
{

    //where the bullet comes from
    public Transform droneBarrel;
    //laser prefab
    public GameObject droneLaser;

    private Animator anim;

    private Transform target;
    Vector2 lastRotation;
    private EnemyMaster enemyMaster;

    public int burstCount;

    void Awake()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        enemyMaster = GetComponentInParent<EnemyMaster>();
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        burstCount = 0;
    }

    void Update()
    {
        if(target)
            LookAtPlayer();

        if (firingReady())
        {
            anim.SetTrigger("firing");
        }


        if (anim.GetCurrentAnimatorStateInfo(0).IsName("DroneGunCharging"))
        {
            burstCount = 0;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("DroneGunFiring") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 2 && burstCount == 2)
        {
            anim.SetTrigger("reload");
        }
    }


    private void LookAtPlayer()
    {
        Vector2 direction = target.position - transform.position;
        if(lastRotation != direction)
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        }
    }


    void Shoot() 
    {
        Instantiate(droneLaser, droneBarrel.transform.position, this.transform.rotation);
        burstCount++;
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

