// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System;

// public class HealthHandler : MonoBehaviour
// {
//     public GameObject Bar;

//     public HealthSystem healthSystem;

//     public static HealthHandler Instance;

//     private void Awake()
//     {
//         Instance = this;

//         healthSystem = new HealthSystem(500);
//     }

//     void Update()
//     {
//         if (Input.GetKeyDown("j"))
//         {
//             healthSystem.Damage(20);
//             Debug.Log("Health: " + healthSystem.GetHealthPercent());

//             Bar.transform.localScale = new Vector3(healthSystem.GetHealthPercent(), 1);
//         }
//         if (Input.GetKeyDown("h"))
//         {   
//             healthSystem.Heal(20);
//             Debug.Log("Health: " + healthSystem.GetHealthPercent());

//             Bar.transform.localScale = new Vector3(healthSystem.GetHealthPercent(), 1);
//         }
//     }

// }
