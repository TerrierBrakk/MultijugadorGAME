using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    Rigidbody2D rbEnemy;
    public float xVel;
    public float yVel;
    float Vel;
    bool PuedeDisp;
    public float fireRate;
    public float health;    


    void Awake()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rbEnemy.velocity = new Vector2(xVel, yVel * -1);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            StaticManager.soundmanager.PlaySound("choque");
            GameObject hit = col.gameObject;
            Barravida vida = hit.GetComponent<Barravida>();

            if(vida !=null)
            {
                vida.TakeDamage(10.0f); 
            }
            
            Die();
           
        }
    }
    public void Diepordisp()
    {
        gameObject.SetActive(false);
        print("Enemigo derrotado");
        UI.scoreValue++;
        
       
    }
    public void Die()
    {
        gameObject.SetActive(false);
    }
    public void Damage()
    {
        health--;
        if (health == 0)
         Diepordisp();
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemydeadend")
        {              
            Die();
        }
    }
}
