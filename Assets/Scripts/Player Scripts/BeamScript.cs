using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamScript : MonoBehaviour
{

    //Add damage scripts here!

    public BeamTurret turret;
    public float beamDamage;
    void Awake()
    {
        turret = GameObject.Find("Player Beam").GetComponent<BeamTurret>();
    }
    void Start()
    {
        beamDamage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            //player.healthSystem.Damage(enemyBulletDamage);
            Debug.Log("Hit the bad guy for " + beamDamage + " damage!");

            //if (player.healthSystem.GetHealth() <= 0)
            {
              //  Destroy(player);
            }
        }
    }
}
