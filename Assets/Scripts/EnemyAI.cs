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

    void Update() {
        if (enemyLaserTimer > 0) {
           enemyLaserTimer--; 
        } else {
            enemyLaserCooldown = false;
        } 

        if (enemyLaserCooldown == false) {

        //Laukaise 1  **Oranssia** Lazer projektiilia vihollisista, mutta ainoastaan niistä-
        //mitkä eivät ole kamikaze vihollisia
        //Teen varmaan jokaiselle eri vihollistyypille oman skriptin? en tiedä

        StartCoroutine(shootEnemyLaser());


        }
    }
    void Awake()
    {
        //mtv tämä edes tarkoittaa
        //se varmaan tekee jotain hyödyllistä joten en kehtaa poistaa
        Instance = this;
    }
    void Start()
    {
        healthSystem = new HealthSystem(100);

        rb = GetComponent<Rigidbody2D>();



    }



        IEnumerator shootEnemyLaser() {


         for (int i = 0; i < 2; i++) {
            enemyLaserCooldown = true;
            enemyLaserTimer = 60;
                Instantiate(projectilePrefabEnemy, transform.position, projectilePrefabEnemy.transform.rotation);

                yield return new WaitUntil(() =>   enemyLaserTimer <= 0);

            enemyLaserTimer = 60;
            }
            //myöhemmin vvvv, ehkä
             //FindObjectOfType<AudioManager>().Play("Pew");
            enemyLaserTimer = 500;
        enemyLaserCooldown = true;


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
