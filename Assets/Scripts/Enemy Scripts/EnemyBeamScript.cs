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

    void Start()
    {
        gameObject.SetActive(false);
        hitDone = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hitDone)
        {
            Fire();
        }
    }

    void Fire()
    {
        RaycastHit2D[] hits;

        hits = Physics2D.RaycastAll(transform.position, -transform.up, Mathf.Infinity, LayerMask.GetMask("Player"));

        if (!hitDone)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];
                Instantiate(explosion, hit.point, transform.rotation);
                Debug.Log("Player directly hit by enemy beam!");

                hitDone = true;
            }
        }
    }

    void Weld()
    {
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(transform.position, -transform.up, Mathf.Infinity, LayerMask.GetMask("Player"));


        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit2D hit = hits[i];

            GameObject objectCollided = hit.transform.gameObject;
            Damageable dmgComponent = objectCollided.GetComponent<Damageable>();

            if(dmgComponent.weldTimer <= 0)
            {
                Instantiate(weldEffect, hit.point, transform.rotation);
                dmgComponent.doDamage(enemyBeamDamage);
                Debug.Log("you imbecile. You have taken " + enemyBeamDamage + " tick damage");
                dmgComponent.weldTimer = 40;
            }
        }        
    }
}
