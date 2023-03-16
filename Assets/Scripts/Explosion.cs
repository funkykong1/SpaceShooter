using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private PlayerBeamScript beam;
    void Awake()
    {
        beam = GameObject.Find("Beam").GetComponent<PlayerBeamScript>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void End()
    {
        Destroy(gameObject);
    }
}
