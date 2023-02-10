using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// plr positio 0, 0, 0 xyz
// jolloin beam positio tulee olla -0.388, 12.258, -12.52142
// tällöin säde tulee suoraan spriten aseesta, luultavasti tosin muuttuu, kun korvataan plr placeholder sprite`
// unity gameobject child?


//This is the player's heavier beam weapon


public class BeamTurret : MonoBehaviour
{
    private Animator anim;

    //references to beam GameObject and its script
    public GameObject beam;
    private BeamScript beamScript;

    //animator bool
    public bool firing;

    // Start is called before the first frame update
    void Start()
    {
        //tell script what is what
        anim = GetComponent<Animator>();
        beamScript = GameObject.Find("Player Beam").GetComponent<BeamScript>();
        firing = false;
    }

    // Update is called once per frame
    void Update()
    {
        //historic vv
        //transform.position = new Vector3 (playerLocation);



        //press Q to vaporize them!
        //No bugs either :)
        if (Input.GetKeyDown(KeyCode.Q) && firingReady())
        {
            ShootBeam();
        }
    }

    //super easily made lol
    //handles whether beam active or no
    public void ShootBeam()
    {
        anim.SetTrigger("firing");
        beam.SetActive(true);
    }
    public void DeactivateBeam()
    {
        beam.SetActive(false);
        anim.SetTrigger("reload");
    }

    //function to house the super long if statement, made it convenient thru bool prefix
    bool firingReady()
    {
        if((anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) && anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerBeamCharge"))
        {
            return true;
        } else {
            return false;
        }
    }
}
