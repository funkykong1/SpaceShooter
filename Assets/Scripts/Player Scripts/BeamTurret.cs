using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// plr positio 0, 0, 0 xyz
// jolloin beam positio tulee olla -0.388, 12.258, -12.52142
// tällöin säde tulee suoraan spriten aseesta, luultavasti tosin muuttuu, kun korvataan plr placeholder sprite
public class BeamTurret : MonoBehaviour
{

    private Animator anim;
    public int beamDamage = 2;

    public bool firing;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        firing = false;
    }

    // Update is called once per frame
    void Update()
    {
        //historic v
        //transform.position = new Vector3 (playerLocation);

        if(firing)
        anim.SetBool("firing", true);
        else 
        anim.SetBool("firing", false);
    }
    public void ShootBeam()
    {
        
    }
}