using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float maxHP;       // This has to be set in the inspector
    public float currentHP;
    public bool welded;

    public GameObject shipExplosion;

    void Awake()
    {

    }

    void Start()
    {
        currentHP = maxHP;
        welded = false;
    }

    public void doDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            //Instantiate(shipExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }
}
