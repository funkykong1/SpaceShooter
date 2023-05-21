using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneEnemy : MonoBehaviour
{
    private EnemyMaster enemyMaster;

    void Update()
    {
        if(enemyMaster.entering == true)
        {
            this.GetComponent<EdgeCollider2D>().enabled = false;
        }
        else
        {
            this.GetComponent<EdgeCollider2D>().enabled = true;
        }
    }
}
