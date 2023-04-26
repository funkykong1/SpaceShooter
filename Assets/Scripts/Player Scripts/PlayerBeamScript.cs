using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBeamScript : MonoBehaviour
{

    //Add damage scripts here!

    public GameObject explosion;
    public GameObject weldEffect;
    public float explosionDamage;
    public float beamDamage;
    public bool hitDone;
    private Transform barrel;
    private BeamTurret turret;
    
    void Awake()
    {
        turret = GameObject.Find("Player Beam").GetComponent<BeamTurret>();
        barrel = GameObject.Find("Barrel").GetComponent<Transform>();
        this.gameObject.SetActive(false);
        explosion.GetComponent<BeamExplosion>().explosionDMG = explosionDamage;
        hitDone = false;
    }
    void Update()
    {
        if(this.isActiveAndEnabled)
            Weld();
    }
    
    //initial bit of damage, explosion here
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !hitDone)
        {
            Fire();
        }
    }

    //secondary bit of damage, welding effect? here
    void OnTriggerStay2D(Collider2D other)
    {
        GameObject objectCollided = other.gameObject;
        Damageable dmgComponent = objectCollided.GetComponent<Damageable>();

        if (dmgComponent)
        {
            dmgComponent.doDamage(beamDamage);
            Debug.Log("Hit the bad guy for " + beamDamage + " tick damage!");
        }
        if (other.CompareTag("LaserBad"))
        {
            //fuck off enemy laser if it dares touch the beam and make a really cool explosion spawn where the intercept happened
            Instantiate(explosion, other.transform.position, transform.rotation);
            Destroy(other.gameObject);
            Debug.Log("get it up you laser sucker");
        }

        Fire();


    }


    //Shoot the raycast and detect initial beam explosion
    void Fire()
    {
        
    //RaycastAll enables piercing
    RaycastHit2D[] hits;
    hits = Physics2D.RaycastAll(barrel.transform.position, transform.up, Mathf.Infinity, LayerMask.GetMask("Enemy"));

    //spawn beam explosions if its the first tick
    for (int i = 0; i < hits.Length; i++)
        {
        RaycastHit2D hit = hits[i];

            //this is the explosion
            if(!hitDone)
            {
                Instantiate(explosion, hit.point, transform.rotation);
                Debug.Log("initial pierce hit " + (i+1) + " times!");
                hitDone = true;
            }

        }
}


    void Weld()
    {
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(barrel.transform.position, transform.up, Mathf.Infinity, LayerMask.GetMask("Enemy"));

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit2D hit = hits[i];
            GameObject objectCollided = hit.transform.gameObject;
            Damageable dmgComponent = objectCollided.GetComponent<Damageable>();

            Instantiate(weldEffect, hit.point, transform.rotation);
            dmgComponent.doDamage(beamDamage);
        }        
    }














    //OLD LINES HERE
    
    //FIRST RAYCAST

            // if(Physics2D.Raycast(barrel.transform.position, transform.up, Mathf.Infinity, LayerMask.GetMask("Enemy")))
        // {
        //     RaycastHit2D hit = Physics2D.Raycast(barrel.transform.position, transform.up, Mathf.Infinity, LayerMask.GetMask("Enemy"));
        //     Instantiate(explosion, hit.point, transform.rotation);
        //     Debug.Log("yea hit i think mmm");
        // } else
        // {
        //     Debug.Log("ignored");
        // }


                //RANDOM EXPLOSION ROTATION

                // float randomZ = Random.Range(0, 359);
                // GameObject spawned = Instantiate(explosion);

                // spawned.transform.position = hit.point;
                // spawned.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, randomZ));

}
