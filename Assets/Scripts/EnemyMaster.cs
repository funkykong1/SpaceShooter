using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaster : MonoBehaviour
{


    private const float START_Y = 0f;

    public float enterSpeed;


    private bool entering = true;

    public static List<GameObject> allEnemies = new List<GameObject>();



    void Awake()
    {
        enterSpeed = 7;
    }
    void Start()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
            allEnemies.Add(go);
    }

    // Update is called once per frame
    void Update()
    {
        if(entering)
        {
            transform.Translate(Vector2.down * Time.deltaTime * enterSpeed);

        if(transform.position.y <= START_Y)
            entering = false;

        }


    }



}
