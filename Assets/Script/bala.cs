using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class bala : NetworkBehaviour
{
    Rigidbody2D rb;
    int dir = 1;

    public void ChangeDirection()
    {
        dir *= -1;
    }

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0,9 * dir); 
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemigo>().Damage();
            gameObject.SetActive(false);
            print("Golpie enemigo");
        }

        if(col.gameObject.tag == "Finish")
        {
            gameObject.SetActive(false);
            print("Golpie fin de escenario");
        }

        GameObject hit = col.gameObject;
        Barravida health = hit.GetComponent<Barravida>();

        if (health != null)
        {
            health.TakeDamage(10f);
        }



    }
}
