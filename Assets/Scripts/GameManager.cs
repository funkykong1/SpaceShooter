using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private PointManager points;

    public bool isGameActive;
    public Button startButton; 
    public Button restartButton;
    public GameObject titleScreen;

    public int currentWave;
    public int enemiesLeft;
    public List<GameObject> enemies;
    public GameObject player;



    void Awake()
    {
        StartGame();
        //wtf does this do?
        if (instance == null)
        {
            instance = this;
        } else 
        {
            Destroy(gameObject);
        }
        points = GameObject.Find("Game Points").GetComponent<PointManager>();

        //wave 0 be nothing
        currentWave = 0;
    }
    //start is called before the umm uhh
    void Start()
    {
        
    }
    void Update()
    {
        if(enemiesLeft <= 0)
        {
            instance.StartCoroutine(instance.SpawnWave());
        }
    }

    public void GameOver()
    {
        Destroy(player);
        //GameManager.GameActive = false;
    } 
    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
        StartCoroutine(SpawnWave());
    }
    private IEnumerator SpawnWave()
    {
        currentWave++;
        Instantiate(enemies[0], points.highPoints[3]);
        enemiesLeft++;
        yield return new WaitForSeconds(3);
    }


}

