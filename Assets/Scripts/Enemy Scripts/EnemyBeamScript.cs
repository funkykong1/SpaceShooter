using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeamScript : MonoBehaviour
{
    //practically just copy pasted plr beam script stuff

     public GameObject explosion;
    public GameObject weldEffect;
    public bool hitDone;
    public float enemyExplosionDamage;
    public float enemyBeamDamage;
    public Transform ship;
    
    void Start()
    {
        gameObject.SetActive(false);
        hitDone = false;
        ship = GetComponentInParent<Transform>();
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
    hits = Physics2D.RaycastAll(ship.transform.position, Vector2.down, Mathf.Infinity, LayerMask.GetMask("Player"));

    //spawn beam explosions if its the first tick
    for (int i = 0; i < hits.Length; i++)
        {

        RaycastHit2D hit = hits[i];
        GameObject objectCollided = hit.transform.gameObject;
        Damageable dmgComponent = objectCollided.GetComponent<Damageable>();
        PlayerHealth hp = objectCollided.gameObject.GetComponent<PlayerHealth>();

            //this is the explosion
            if(!hitDone)
            {
                Instantiate(explosion, hit.point, transform.rotation);
                print(hit.point);
                hp.currHealth -= enemyBeamDamage;
                dmgComponent.weldTimer = 70;
            }
        }
    hitDone = true;
    }


    void Weld()
    {
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(ship.transform.position, Vector2.down, Mathf.Infinity, LayerMask.GetMask("Player"));


        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit2D hit = hits[i];

            GameObject objectCollided = hit.transform.gameObject;
            Damageable dmgComponent = objectCollided.GetComponent<Damageable>();
            PlayerHealth hp = objectCollided.gameObject.GetComponent<PlayerHealth>();

            if(dmgComponent.weldTimer <= 0)
            {
                Instantiate(weldEffect, hit.point, transform.rotation);
                hp.currHealth -= enemyBeamDamage;
                dmgComponent.weldTimer = 70;
            }
        }        
    }
}
