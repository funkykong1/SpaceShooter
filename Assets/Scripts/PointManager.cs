using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{

    // points where the bad guys go upon spawning
    // numbered left to right
    public GameObject[] HighPoints;
    public GameObject[] MidPoints;
    public GameObject[] LowPoints;
    public GameObject[] BossPoints;

    private MeshRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        //make the dots go away :)
        rend = GetComponent<MeshRenderer>();
        rend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
