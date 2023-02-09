using UnityEngine;





    //--CTRL C + CTRL K to apply comments to lines
    //This is the player's fast charging assault weapon

public class LaserTurret : MonoBehaviour
{
    //where the bullet comes from
    public Transform playerBarrel;
    //laser prefab
    public GameObject playerLaser;

    //fuck this one
    private Animator anim;
    //animator bool
    public bool firing;
    //how many lazers playa allowed ta shoot? Powerup here?
    public int burstCount;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        firing = false;
        burstCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && firingReady())
        {
            anim.SetTrigger("firing");
        }


        if (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerLaserCharge"))
        {
            burstCount = 0;
        }

        Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }


    //use animation events instead of manual timing!
    void Shoot() 
    {
        Instantiate(playerLaser, playerBarrel.transform.position, playerLaser.transform.rotation);

        burstCount++;
        anim.SetInteger("burstCount", burstCount);
        
    }

    //single bool function to house the horrible if statement
    bool firingReady()
    {
        if((anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) && anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerLaserCharge") || (anim.GetCurrentAnimatorStateInfo(0).IsName("StartCharge")
         && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1))
        {
            return true;
        } else {
            return false;
        }
    }
}

