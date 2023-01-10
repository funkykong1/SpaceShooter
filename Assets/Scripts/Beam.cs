using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// plr positio 0, 0, 0 xyz
// jolloin beam positio tulee olla -0.388, 12.258, -12.52142
// tällöin säde tulee suoraan spriten aseesta, luultavasti tosin muuttuu, kun korvataan plr placeholder sprite
public class Beam : MonoBehaviour
{

    [SerializeField]


    Rigidbody2D rb;
    Vector3 playerLocation;
    public int beamDamage = 34;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3 (playerLocation);
    }
}
