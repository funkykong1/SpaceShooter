using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This is the player's heavier beam weapon


public class BeamTurret : MonoBehaviour
{
    private Animator anim;

    //references to beam GameObject and its script
    public GameObject beam;
    private PlayerBeamScript beamScript;

    void Awake()
    {
        //tell script what is what
        anim = GetComponent<Animator>();
        beamScript = beam.GetComponent<PlayerBeamScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //press Q to vaporize the bad guys
        //No bugs either :)
        if (Input.GetKeyDown(KeyCode.Q) && firingReady())
        {
            ShootBeam();
        }
    }

    //handles whether beam active or no
    public void ShootBeam()
    {
        anim.SetTrigger("firing");
        beam.SetActive(true);
    }
    public void DeactivateBeam()
    {
        beamScript.hitDone = false;
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

    //ANIMATION EVENTS
    public void hitTrue()
    {
        beamScript.hitDone = true;
    }
}
