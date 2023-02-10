using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //playr hp.
    public float health;
    public float maxHealth;
    private float m_health;

    //hp bar references
    public Image healthBar;
    public Gradient gradient;

    //use list instead of just an image[]
    //BECAUSE the count function is exclusive to list
    //I don't know
    public List<Image> bothBars = new List<Image>();
    public float fadeSpeed;
    public float fadeTimer;

    //is FadeOut running?
    private bool CR_running;


    // Start is called before the first frame update
    void Start()
    {
        //set bools
        CR_running = false;
        maxHealth = health;
        m_health = health;
        //update hp bar color once
        healthBar.color = gradient.Evaluate(health / 100);
        //hp bar fade out timer
        ResetTimer();

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        //0 is empty and 1 is completely full, therefore we divide by the amount of health in the plane
        //healthBar.color = gradient.Evaluate(health / 100);
        if(health != m_health)
        {
            healthBar.color = gradient.Evaluate(health / 100);
            StartCoroutine(FadeIn());
            m_health = health;
            ResetTimer();
        }

        //timer which tells us if plr taken damage recently
        if (fadeTimer > 0)
        {
        fadeTimer--;
        } else {
        StartCoroutine(FadeOut());
        }

    }

    //happens when plr takes damage; prevents fading out before timer 0
    void ResetTimer()
    {
        fadeTimer = 600f;
    }

    IEnumerator FadeIn()
    {
        //is fadeout running? stop it 
        //this makes it fade good all the time and avoids buggy shenanigans with the bar
        if (CR_running == true)
        {
            StopCoroutine(FadeOut());
        }
        float alpha = bothBars[0].color.a;
        while (alpha < 1)
        {
            alpha += Time.deltaTime * fadeSpeed;
            for (int i = 0; i < bothBars.Count; i++)
            {
                bothBars[i].color = new Color(bothBars[i].color.r, bothBars[i].color.g, bothBars[i].color.b, alpha);
            }
            yield return null;
        }
    }


    IEnumerator FadeOut()
    {
        CR_running = true;
        float alpha = bothBars[0].color.a;
        while (alpha > 0.2)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            for (int i = 0; i < bothBars.Count; i++)
            {
                bothBars[i].color = new Color(bothBars[i].color.r, bothBars[i].color.g, bothBars[i].color.b, alpha);
            }
            yield return null;
        }
        CR_running = false;
    }
}
