using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public static EnemyAI Instance;

    public HealthSystem healthSystem;
    Rigidbody2D rb;
    
    public GameObject projectilePrefabEnemy;

    public float  enemyLaserTimer = 800;
    public bool enemyLaserCooldown = true;

    //bullets will phase through inactive enemies
    public bool enemyVisible = false;
    //enemy will move to assigned patrol point until true
    public bool enemyReady = false;
    public float health = 100;

    //references 2 animator
    private Animator anim;
    public bool firing = false;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        healthSystem = new HealthSystem(100);

        rb = GetComponent<Rigidbody2D>();

    }
    void Update() {
        //play firing lazer animation if firing true
        if (firing)
        anim.SetBool("firing", true);

        if (transform.position.y < 17)
        {
            //start firing and become hittable
            enemyVisible = true;
        }
        if (enemyReady == true)
        {
            //stop moving

        }

        if (enemyReady = false;)
        {
        //go down when active false
        reachPoint();
        }
        

        if (enemyVisible == true) {

            //enemy shooting
            if (enemyLaserTimer > 0) {
              enemyLaserTimer--; 
            } else {
                enemyLaserCooldown = false;
            } 

            if (enemyLaserCooldown == false) {
            //laukaisee yhden oranssia laaseria vihollisesta
            StartCoroutine(shootEnemyLaser());
        }
        }
    }




        IEnumerator shootEnemyLaser() {

        //enemylasertimer is how often the thing fires
         for (int i = 0; i < 1; i++) {
            enemyLaserCooldown = true;
                firing = true;
                Instantiate(projectilePrefabEnemy, transform.position, projectilePrefabEnemy.transform.rotation);

                yield return new WaitUntil(() =>   enemyLaserTimer <= 0);

            }
            //myöhemmin vvvv, ehkä
             //FindObjectOfType<AudioManager>().Play("Pew");
            enemyLaserTimer = 500;
        enemyLaserCooldown = true;


    }


    public void reachPoint()
    {

    }

    // private void FindDirectionToEnemy()
    // {
    //     dirToPlayer = PlayerMovement.Instance.gameObject.transform.position - transform.position;
    // }

    // private void FindTarget()
    // {
    //     float targetRange = 50f;
    //     if (Vector3.Distance(transform.position, PlayerMovement.Instance.transform.position) < targetRange)
    //     {
    //         transform.up = dirToPlayer;
    //         Vector2 targetPosition = Vector2.MoveTowards(transform.position, PlayerMovement.Instance.transform.position, speed * Time.deltaTime);
    //         rb.MovePosition(targetPosition);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.CompareTag("Bullet"))
        {
            healthSystem.Damage(50);
            // Debug.Log("EnemyHP: " + healthSystem.GetHealthPercent());
            print("Hit");

            if (healthSystem.GetHealth() <= 0)
            {
                Die();
            }
        }*/
        if (collision.CompareTag("Player"))
        {
            Die();
        }

    }
    
    public void Die()
    {
        Destroy(gameObject);
        //FindObjectOfType<AudioManager>().Play("EnemyDeath");
    }
    
}
