using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Nave : NetworkBehaviour
{
     
    public Text hits;

    //GameObject para la bala
    public GameObject Bala;
    //Gameobject para la posicion de la bala
    public GameObject a;
    int contador = 0;
    

    Rigidbody2D rbody;
    //Velocidad de movimiento
    public float speed;


    //Variable para delay del disparo
    int delay = 0;
    // Start is called before the first frame update
  
    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        
    }    
   
    // Update is called once per framer
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        Movement();

        if (Input.GetKey(KeyCode.Space) && delay > 8)        
            CmdShoot();
            delay++;
        
        
    }
  

    void Movement() {
        rbody.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rbody.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));
    }
     
    [Command]
    void CmdShoot()
    {
       StaticManager.soundmanager.PlaySound("disparo");
        RpcClientShoot(); 
    }
    [ClientRpc]
    void RpcClientShoot()
    {
        delay = 0;
        Instantiate(Bala, a.transform.position, Quaternion.identity);
    }
    void DamageSounds()
    {
       /* if (Barravida.health <= 60.0f && Barravida.health >=40.0f)
        {
           // StaticManager.soundmanager.PlaySound("light");
        }
        if (Barravida.health <= 30.0f && Barravida.health >= 20.0f)
        {
            //StaticManager.soundmanager.PlaySou nd("moderate");
        }
        if (Barravida.health <= 10.0f && Barravida.health >= 0.1f)
        {
            //StaticManager.soundmanager.PlaySound("heavy");
        }*/
    }
   
   public void Puntuacion()
    {        
      contador++;
      hits.text= contador.ToString();
    }
}
