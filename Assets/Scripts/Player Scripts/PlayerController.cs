using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerController : MonoBehaviour
{

    //used for movement
    public float horizontalInput;
    public float verticalInput;

    private Camera mainCamera;
    

    //adjust via editor
    public float xRange;
    public float yRange;

    public float shipSpeed = 10;

    //idk
    public static PlayerController Instance;
    
    private PlayerHealth playerHealth;


    public Transform playerBarrel;
    private GameManager gameManager;
    void Awake()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerHealth = this.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameManager.gameActive)
            return;
        
        // Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        // if(gameManager.gameActive)
        //     transform.position = mousePosition;
        // else
        //     transform.position = new Vector2(0, 50);

        if(playerHealth.currHealth <= 0)
        {
            gameManager.gameActive = false;
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

        if (transform.position.y > -1 && gameManager.gameActive)
        {
            transform.position = new Vector3(transform.position.x, -1, transform.position.z);
        }

        //moves the plane
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * shipSpeed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * shipSpeed);

    }
}
    

