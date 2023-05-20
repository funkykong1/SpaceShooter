using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] allEnemySets;

    private GameObject currentSet;
    private Vector2 spawnPos = new Vector2(0,25);

    private static GameManager instance;

    private int currentWave;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

    }

    private void Start()
    {
        currentWave = 0;
        SpawnNewWave();
    }

    public static void SpawnNewWave()
    {
        instance.StartCoroutine(instance.SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        if(currentSet != null)
            Destroy(currentSet);

        
        yield return new WaitForSeconds(3);

        currentSet = Instantiate(allEnemySets[currentWave], spawnPos, Quaternion.identity);
        currentWave++;
    }
}
