using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerController : MonoBehaviour
{



    public float horizontalInput;
    public float verticalInput;

    public bool cooldown = false;
    public float speed = 10.0f;
    public float xRange = 9.0f;
    public float yRange = 4.5f;

    public static PlayerController Instance;
    
    public HealthSystem healthSystem;
    Rigidbody2D rb;
    public float playerHp = 100f;
        
    public GameObject projectilePrefab;

    public float burstCooldown = 0;
    public bool beam = false;

    public Vector3 playerLocation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerLocation = transform.position;
        //rajat pelaajalle. 4.3.2022
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        //yläraja pelaajalle 25.4.2022 -_-
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }

        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space) && (cooldown == false)) {

        //laukaise -Sandwich- -AMMUS!!!!- KOLME (tai neljä) AMMUSTA!!!!! pelaajasta
        StartCoroutine(shootBurst());


        }
        //scuffed tapa pistää laser ase ampumaan neljä kertaa, eikä kaikkia neljää
        //-ammusta samaan aikaan
        if (burstCooldown > 0) {
            burstCooldown--;

        } else {
            cooldown = false;

        }
    }


//      Inhottava osio koodia, en edes tiedä mitä IEnumerator tai yield return tarkoittaa
//      Kesti aidosti jokin 4 tuntia etsiä jokin keino, jolla pistää koodi odottamaan noin .3 sekuntia
//      jokaisen ammuksen jälkeen
//      tehty valmiiksi klo 4:00, en enää ikinä koske tähän*

    IEnumerator shootBurst() {


         for (int i = 0; i < 4; i++) {

                cooldown = true;
                burstCooldown = 8;
                Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
                yield return new WaitUntil(() => burstCooldown <= 0);

                burstCooldown = 8;
            }

             //FindObjectOfType<AudioManager>().Play("Pew");
             burstCooldown = 100;
        

    }

        public void Die()
    {
        Destroy(gameObject);
        //FindObjectOfType<AudioManager>().Play("EnemyDeath");
    }

    }

    

