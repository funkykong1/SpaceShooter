using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float maxHP;       // This has to be set in the inspector
    public float currentHP;
    public float weldTimer;

    public GameObject shipExplosion;

    void Update()
    {
        weldTimer--;
    }

    void Start()
    {
        currentHP = maxHP;
    }

    public void doDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            if(EnemyMaster.allEnemies.Count <= 0)
                GameManager.SpawnNewWave();

            Instantiate(shipExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }
}
