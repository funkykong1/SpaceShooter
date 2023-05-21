using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamEnemy : MonoBehaviour
{
    private Animator anim;

    private bool isVisible;
    private float health;
    public GameObject enemyBeam;
    private EnemyBeamScript enemyBeamScript;
    private EnemyMaster enemyMaster;
    
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        enemyBeamScript = enemyBeam.GetComponent<EnemyBeamScript>();
        enemyMaster = GetComponentInParent<EnemyMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (firingReady() && enemyMaster.entering == false)
            ShootEnemyBeam();

        if(enemyMaster.entering == true)
        {
            this.GetComponent<EdgeCollider2D>().enabled = false;
        }
        else
        {
            this.GetComponent<EdgeCollider2D>().enabled = true;
        }
    }

    public void ShootEnemyBeam()
    {
        anim.SetTrigger("firing");
        enemyBeam.SetActive(true);
    }
    public void DeactivateEnemyBeam()
    {
        enemyBeamScript.hitDone = false;
        enemyBeam.SetActive(false);
        anim.SetTrigger("reload");
    }
    bool firingReady()
    {
        if((anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) && anim.GetCurrentAnimatorStateInfo(0).IsName("EnemyBeamCharge"))
        {
            return true;
        } else {
            return false;
        }
    }
}
