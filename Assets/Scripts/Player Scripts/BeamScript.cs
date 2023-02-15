using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamScript : MonoBehaviour
{

    //Add damage scripts here!

    private BeamTurret turret;
    public GameObject explosion;
    public float explosionDamage;
    public float beamDamage;
    public bool hitDone;
    public Transform barrel;
    
    void Awake()
    {
        turret = GameObject.Find("Player Beam").GetComponent<BeamTurret>();
    }
    void Start()
    {
        gameObject.SetActive(false);
        beamDamage = 0.5f;
        hitDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //initial bit of damage, explosion here


        
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit the bad guy for " + explosionDamage + " INITIAL damage!");
            Fire();
            Invoke("hitReset", 2.5f);
        }
    }



    //secondary bit of damage, welding effect? here
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit the bad guy for " + beamDamage + " tick damage!");
        }
    }

    void Fire()
    {
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(barrel.transform.position, transform.up, Mathf.Infinity, LayerMask.GetMask("Enemy"));

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit2D hit = hits[i];
            Instantiate(explosion, hit.point, transform.rotation);
            Debug.Log("pierce hit " + i + " times!");
        }


        //old

        // if(Physics2D.Raycast(barrel.transform.position, transform.up, Mathf.Infinity, LayerMask.GetMask("Enemy")))
        // {
        //     RaycastHit2D hit = Physics2D.Raycast(barrel.transform.position, transform.up, Mathf.Infinity, LayerMask.GetMask("Enemy"));
        //     Instantiate(explosion, hit.point, transform.rotation);
        //     Debug.Log("yea hit i think mmm");
        // } else
        // {
        //     Debug.Log("ignored");
        // }
    }
    void hitReset()
    {
        hitDone = false;
    }
}
