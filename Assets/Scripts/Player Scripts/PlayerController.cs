using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerController : MonoBehaviour
{

    public ShipStats shipStats;

    //used for movement
    public float horizontalInput;
    public float verticalInput;
    

    //adjust via editor
    public float xRange;
    public float yRange;

    //idk
    public static PlayerController Instance;
    private PlayerHealth playerHealth;
    
    //fix this --done


    //note: make the guns separate gameobjects
    //put the firing script there when its time
    //note: ok done
    public Transform playerBarrel;
    private GameManager gameManager;
    void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerHealth = GetComponent<PlayerHealth>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth.health <= 0)
        {
            // nuh gameManager.GameOver();
        }
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
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * shipStats.speed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * shipStats.speed);

    }
}
    

