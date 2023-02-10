using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyhealth;
    public float enemyMaxHealth;
    

    void Awake()
    {
        //if forgot to assign hp for enemy in editor, make it 100
        if(enemyhealth == 0)
        {
            enemyhealth = 100;
        }
    }

    void Start()
    {
        enemyMaxHealth = enemyhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
