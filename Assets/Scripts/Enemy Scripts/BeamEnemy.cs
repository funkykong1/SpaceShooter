using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamEnemy : MonoBehaviour
{
    public GameObject EnemyBeam;
    private Animator anim;

    private bool isVisible;
    private float health;

    public bool firing;
    public GameObject enemyBeam;
    private EnemyBeamScript enemyBeamScript;
    
    
    void Awake()
    {
        enemyBeamScript = enemyBeam.GetComponent<EnemyBeamScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootEnemyBeam()
    {
        anim.SetTrigger("firing");
        enemyBeam.SetActive(true);
    }
    public void DeactivateEnemyBeam()
    {
        enemyBeamScript.HitFalse();
        enemyBeam.SetActive(false);
        anim.SetTrigger("reload");
    }
}
