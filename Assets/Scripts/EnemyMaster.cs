using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMaster : MonoBehaviour
{


    private const float START_Y = 1.5f;


    private bool entering = true;

    public static List<GameObject> allEnemies = new List<GameObject>();



    // Start is called before the first frame update
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
            transform.Translate(Vector2.down * Time.deltaTime * 10);

        if(transform.position.y <= START_Y)
            entering = false;

        }
    }

}
