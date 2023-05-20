using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBeamScript : MonoBehaviour
{

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
        hitDone = false;
    }
    void Update()
    {
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
        GameObject objectCollided = hit.transform.gameObject;
        Damageable dmgComponent = objectCollided.GetComponent<Damageable>();

            //this is the explosion
            if(!hitDone)
            {
                Instantiate(explosion, hit.point, transform.rotation);
                print(hit.point);
                dmgComponent.doDamage(explosionDamage);
                dmgComponent.weldTimer = 100;

                Debug.Log("initial pierce hit " + (i+1) + " times!");
            }
        }
    hitDone = true;
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

            if(dmgComponent.weldTimer <= 0)
            {
                Instantiate(weldEffect, hit.point, transform.rotation);
                dmgComponent.doDamage(beamDamage);
                Debug.Log("Hit the bad guy for " + beamDamage + " tick damage");
                dmgComponent.weldTimer = 40;
            }
        }        
    }
}
