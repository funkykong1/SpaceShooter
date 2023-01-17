using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAltController : MonoBehaviour
{
    public float speed = 5f;

    public float min_Y, max_Y;
    //public float min_X, max_X;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        //returns w/s & arrow up/down
        if(Input.GetAxisRaw("Vertical") > 0f) {

            //make a temporary vector3 to store plr location
            Vector3 temp = transform.position;
            //adds some value to the vector3 when w is pressed
            temp.y += speed * Time.deltaTime;
            //makes the player not go over the border of the game
            if (temp.y > max_Y)
                temp.y = max_Y;
            //updates temp so the function can restart and make the plr go up
            transform.position = temp;

        } else if(Input.GetAxisRaw("Vertical") < 0f) {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;

            if (temp.y < min_Y)
                temp.y = min_Y;

                transform.position = temp;

        }
    }
}
