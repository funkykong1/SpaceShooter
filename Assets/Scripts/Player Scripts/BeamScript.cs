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
    void OnCollisionEnter2D(Collision2D other)
    {
            foreach(ContactPoint2D hitPos in other.contacts)
            {
                Instantiate(explosion, hitPos.point, Quaternion.identity);
                Debug.Log(hitPos.point);
            }
        
    }
    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Enemy") && !hitDone)
    //     {
    //         Debug.Log("Hit the bad guy for " + explosionDamage + " INITIAL damage!");

    //         Vector2 explodeHere = transform.position;
    //         Instantiate(explosion, explodeHere, other.transform.rotation);
    //         hitDone = true;
    //         Invoke("hitReset", 3f);
    //     }
    // }

    //secondary bit of damage, welding effect? here
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit the bad guy for " + beamDamage + " tick damage!");
        }
    }
    void hitReset()
    {
        hitDone = false;
    }
}
