using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public GameObject player;
    public bool isGameActive;
    public Button startButton; 
    public Button restartButton;
    public GameObject titleScreen;
    public int currentWave;



    void Awake()
    {
        //wtf does this do?
        if (instance == null)
        {
            instance = this;
        } else 
        {
            Destroy(gameObject);
        }

        //wave 0 be nothing
        currentWave = 0;
    }
    //start is called before the umm uhh
    void Start()
    {
        
    }

    public void GameOver()
    {
        Destroy(player);
        //GameManager.GameActive = false;
    } 
    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
        instance.StartCoroutine(instance.SpawnWave());
    }
    private IEnumerator SpawnWave()
    {
        currentWave++;
        
        yield return new WaitForSeconds(3);
    }
}

