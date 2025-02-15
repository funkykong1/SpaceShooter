using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] allEnemySets;

    private GameObject currentSet;
    private Vector2 spawnPos = new Vector2(0,25);

    private static GameManager instance;

    public bool gameActive;

    private int currentWave;
    private GameObject plr;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        plr = GameObject.Find("Player");

    }

    void Update()
    {
        if(plr == null)
        {
            instance.StartCoroutine(Restart());
        }
    }

    public void StartGame()
    {
        plr.transform.position = new Vector2(0,-5);
        currentWave = 0;
        GameObject.Find("Text").SetActive(false);
        SpawnNewWave();
        gameActive = true;
    }

    public static void SpawnNewWave()
    {
        instance.StartCoroutine(instance.SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        if(currentWave > allEnemySets.Count()-1)
        {
            plr.GetComponent<PlayerHealth>().currHealth -= 125;
            yield return null;
        }
        if(currentSet != null)
            Destroy(currentSet);

        
        yield return new WaitForSeconds(3);

        currentSet = Instantiate(allEnemySets[currentWave], spawnPos, Quaternion.identity);
        currentWave++;
        
    }

    public IEnumerator Restart()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
