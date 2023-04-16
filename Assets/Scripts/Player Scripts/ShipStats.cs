using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ShipStats
{
    public int maxHealth;
    [HideInInspector]
    public int currentHealth;
    [HideInInspector]
    public int laserDamage;
    [HideInInspector]
    public float beamDamage;
    [HideInInspector]
    public int explosionDamage;

    public float shipSpeed;
    public float fireRate;
}
