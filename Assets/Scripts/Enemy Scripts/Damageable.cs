using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float maxHP;       // This has to be set in the inspector
    public float currentHP;
    public float weldTimer;

    public GameObject shipExplosion;

    private SpriteRenderer rend;
    private Color clr = new Color(1, 0.55f, 0.55f, 1);

    private bool colorRunning = false;


    void Update()
    {
        weldTimer--;
    }

    void Start()
    {
        currentHP = maxHP;
        rend = GetComponent<SpriteRenderer>();
    }

    public void doDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            EnemyMaster.allEnemies.Remove(gameObject);
            Instantiate(shipExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

                    
        //player color red upon taking damage
        if(colorRunning)
        {
            StopCoroutine(ColorRoutine());
            colorRunning = false;
        }
            
        StartCoroutine(ColorRoutine());

        
    }

    private IEnumerator ColorRoutine()
    {
        colorRunning = true;
        rend.color = clr;

        while(clr.g < 1)
        {
            clr.b+= Time.deltaTime * 2;
            clr.g+= Time.deltaTime * 2;
            rend.color = clr;
            yield return new WaitForFixedUpdate();
        }


        colorRunning = false;
        clr = new Color(1,0.55f,0.55f,1);
        yield return rend.color = new Color(1,1,1,1);
    }
}
