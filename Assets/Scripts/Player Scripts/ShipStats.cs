using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ShipStats
{
    public int maxHealth = 100;
    [HideInInspector]
    public int currentHealth;
    [HideInInspector]
    public int laserDamage = 30;
    [HideInInspector]
    public float beamDamage = 1;
    [HideInInspector]
    public int explosionDamage = 35;

    public float speed;
    public float fireRate;
}
