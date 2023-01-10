using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemyPrefabs;

    private float spawnRangeX = 10;
    private float startDelay = 2;

    public 
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
        Invoke("SpawnRandomEnemy", startDelay);
    }



    // Update is called once per frame
    void Update()
    {
        //randomly set animal index and animal spawn position
        
    }
    void SpawnRandomEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 10, 0);

        int enemyIndex = Random.Range(0, enemyPrefabs.Length);

        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }
}
