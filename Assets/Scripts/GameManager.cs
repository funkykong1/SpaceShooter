using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public SpawnManager spawnManager;
    //public GameObject Boss[];

    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Destroy(player);
        //GameManager.GameActive = false;
        //FindObjectOfType<AudioManager>().Play("EnemyDeath");
    }
}

