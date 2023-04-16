using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBeamScript : MonoBehaviour
{

    //Add damage scripts here!

    public GameObject explosion;
    public GameObject shipExplosion;
    public float explosionDamage;
    public float beamDamage;
    public bool hitDone;
    
    private Transform barrel;
    private BeamTurret turret;
    
    void Awake()
    {
        turret = GameObject.Find("Player Beam").GetComponent<BeamTurret>();
        barrel = GameObject.Find("Barrel").GetComponent<Transform>();
    }
    void Start()
    {
        beamDamage = 0.5f;
        hitDone = false;
        gameObject.SetActive(false);
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
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit the bad guy for " + beamDamage + " tick damage!");
        }
        else if (other.CompareTag("LaserEnemy"))
        {
            //fuck off enemy laser if it dares touch the beam
            //make a really cool explosion spawn where the intercept happened
            Instantiate(explosion, other.transform.position, transform.rotation);
            Destroy(other.gameObject);
        }
    }


    //Shoot the raycast and detect initial beam explosion
    void Fire()
    {
        //RaycastAll enables piercing
        RaycastHit2D[] hits;
        //LaserEnemy tag will also explode le- nvm
        hits = Physics2D.RaycastAll(barrel.transform.position, transform.up, Mathf.Infinity, LayerMask.GetMask("Enemy"));

        //spawn beam explosions if its the first tick
        if (!hitDone)
        {
            hitDone = true;
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];
                Instantiate(explosion, hit.point, transform.rotation);
                Debug.Log("initial pierce hit " + (i+1) + " times!");
            }
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
