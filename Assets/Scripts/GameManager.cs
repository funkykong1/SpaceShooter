using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Destroy(Player);
        //GameManager.GameActive = false;
        //FindObjectOfType<AudioManager>().Play("EnemyDeath");
    }
}

