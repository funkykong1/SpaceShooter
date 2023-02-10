using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    private SpriteRenderer rend;

    // Start is called before the first frame update
    //commented out for debug purposes
    
    void Start()
    {
        //make the dots go away :)
        rend = GetComponent<SpriteRenderer>();
        //rend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
