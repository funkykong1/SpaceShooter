using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaster : MonoBehaviour
{


    private const float START_Y = 0f;

    public float enterSpeed;


    public bool entering = true;

    public int enemies;

    [SerializeField]
    public List<GameObject> allEnemies = new List<GameObject>();



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
        enemies = allEnemies.Capacity;
        if(entering)
        {
            transform.Translate(Vector2.down * Time.deltaTime * enterSpeed);

        if(transform.position.y <= START_Y)
            entering = false;

        }

        if(allEnemies.Count == 0)
            GameManager.SpawnNewWave();

    }

}
