using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public Image healthBar;
    public Gradient gradient;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;

        healthBar.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        //0 is empty and 1 is compeltely full, therefore we divide by the amount of health in the plane
        healthBar.color = gradient.Evaluate(health / 100);
    }
}
