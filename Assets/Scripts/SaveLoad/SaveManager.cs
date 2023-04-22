using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
public static SaveManager instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        LoadProgress();
    }

    public static void SaveProgress()
    {
        SaveObject so = new SaveObject();

        so.highscore = UIManager.GetHighScore();
        so.shipStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().shipStats = so.shipStats;
    }

    public static void LoadProgress()
    {
        SaveObject so = SaveLoad.LoadState();

        UIManager.UpdateHighscore(so.highscore);

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().shipStats = so.shipStats;
    }
}