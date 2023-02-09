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


    //note: make the guns separate gameobjects
    //put the firing script there when its time
    public GameObject playerBeam;
    private BeamTurret beamScript;

    public GameObject playerLaser;
    private LaserTurret laserScript;


    public Transform playerBarrel;

    private Animator playerAnim;


    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        laserScript = GameObject.Find("Player Laser").GetComponent<LaserTurret>();
        beamScript = GameObject.Find("Player Beam").GetComponent<BeamTurret>();

    }

    public void Die()
    {
        Destroy(gameObject);
        //GameManager.GameActive = false;
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

    }
}

    

