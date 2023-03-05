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
        if (instance == null)
        {
            instance = this;
        } else 
        {
            Destroy(gameObject);
        }
        currentWave = 1;
    }


    public void GameOver()
    {
        Destroy(player);
        //GameManager.GameActive = false;
    }
    public void StartGame()
    {
        instance.StartCoroutine(instance.SpawnWave(currentWave));
    }
    private IEnumerator SpawnWave(int waveNumber)
    {
        currentWave++;
        yield return new WaitForSeconds(3);
    }
}

