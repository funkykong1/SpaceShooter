using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamScript : MonoBehaviour
{

    //Add damage scripts here!

    public BeamTurret turret;
    // Start is called before the first frame update
    void Start()
    {
        turret = GameObject.Find("Player Beam").GetComponent<BeamTurret>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
