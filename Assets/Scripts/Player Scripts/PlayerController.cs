using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerController : MonoBehaviour
{


    //used for movement
    public float horizontalInput;
    public float verticalInput;
    
    //burst laser cd
    public bool cooldown = false;

    //adjust via editor
    public float speed;
    public float xRange;
    public float yRange;

    //idk
    public static PlayerController Instance;
    public PlayerHealth PlayerHealth;
    
    //fix this --done
    public GameObject projectilePrefab;


    //note: make the guns separate gameobjects
    //put the firing script there when its time
    public GameObject playerBeam;
    public GameObject playerLaser;
    public bool beam = false;

    private Animator playerAnim;

    //menu screen or ingame?
    private bool GameActive;

    // Start is called before the first frame update
    void Start()
    {
        GameActive = true;
        playerAnim = GetComponent<Animator>();

    }

    public void Die()
    {
        Destroy(gameObject);
        GameActive = false;
        //FindObjectOfType<AudioManager>().Play("EnemyDeath");
    }

    // Update is called once per frame
    void Update()
    {

        //handles game screen borders
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }

        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }

        //moves the plane
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space) && (cooldown == false)) {

        //Laukaise neljä ammusta pelaajasta
        StartCoroutine(shootBurst());


        }
        //scuffed tapa pistää laser ase ampumaan neljä kertaa, eikä kaikkia neljää
        //-ammusta samaan aikaan

    }



    IEnumerator shootBurst() 
    {
        //shoots i < x amount of times
        //probably need to adjust burst cd
        for (int i = 0; i < 3; i++) 
        {
            yield return Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

        //FindObjectOfType<AudioManager>().Play("Pew");   
    }
}

    

