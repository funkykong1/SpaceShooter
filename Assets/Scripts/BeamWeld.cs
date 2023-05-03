using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamWeld : MonoBehaviour
{

    public float endTime;
    void End()
    {
        Destroy(gameObject, endTime);
    }

    void OnTriggerExit2D()
    {

    }

}
