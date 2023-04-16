using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeamScript : MonoBehaviour
{
    //practically just copy pasted plr beam script stuff

    public GameObject explosion;
    private Transform barrel;

    
    public bool hitDone;
    public float enemyBeamDamage;



    // Start is called before the first frame update
    void Start()
    {
        enemyBeamDamage = 0.5f;
        hitDone = false;
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hitDone)
        {
            Fire();
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player dealt " + enemyBeamDamage + " tick damage");
        }
        else if (other.CompareTag("LaserPlayer"))
        {
            //fuck off enemy laser if it dares touch the beam
            //make a really cool explosion spawn where the intercept happened
            Instantiate(explosion, other.transform.position, transform.rotation);
            Destroy(other.gameObject);
        }
    }

    //makes the explosion happen if the first frame of the beam's activation is ontop of player
    void Fire()
    {
        //RaycastAll enables piercing
        RaycastHit2D[] hits;
        //LaserEnemy tag will also explode le- nvm
        hits = Physics2D.RaycastAll(barrel.transform.position, -transform.up, Mathf.Infinity, LayerMask.GetMask("Player"));

        //spawn beam explosions if its the first tick
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
}
