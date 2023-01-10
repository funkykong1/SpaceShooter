using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    EnemyAI[] enemyAmount;
    

    [SerializeField]
    private float rotationSpeed;
    float fireRate;
    float nextFire;

    void Start()
    {
        fireRate = 0.5f;
        nextFire = Time.time;
    }

    void Update()
    {
        CheckIfTimeToFire();
    }
    void CheckIfTimeToFire()
    {
        enemyAmount = GameObject.FindObjectsOfType<EnemyAI>();

        if (enemyAmount.Length > 0)
        {
            if (Time.time > nextFire)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                nextFire = Time.time + fireRate;
                //FindObjectOfType<AudioManager>().Play("Shot");
            }
        }
        
    }
}
