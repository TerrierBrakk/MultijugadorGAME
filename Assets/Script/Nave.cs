using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nave : MonoBehaviour
{
     
    public Text hits;

    //GameObject para la bala
    public GameObject Bala;
    //Gameobject para la posicion de la bala
    GameObject a;
    int contador = 0;
    

    Rigidbody2D rbody;
    //Velocidad de movimiento
    public float speed;


    //Variable para delay del disparo
    int delay = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        a = transform.Find("Single").gameObject;
    }    
   
    // Update is called once per framer
    void Update()
    {

        Movement();

        if (Input.GetKey(KeyCode.Space) && delay > 8)            
            Shoot();
            delay++;       
    }
   
    public void Damage()
    {
        Barravida.health -= 10.0f;
        Playerdeath();
        DamageSounds();
    }
    

    public void Playerdeath()
    {
        if (Barravida.health <= 0)
        {
            gameObject.SetActive(false);
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
            //print(vidas.lifes);
            // vidas.lifes -= 1;
        }
    }

    void Movement() {
        rbody.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rbody.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));
    }
      
    void Shoot()
    {
       StaticManager.soundmanager.PlaySound("disparo");
        delay = 0;
        Instantiate(Bala, a.transform.position, Quaternion.identity);
      
    }

    void DamageSounds()
    {
        if (Barravida.health <= 60.0f && Barravida.health >=40.0f)
        {
            StaticManager.soundmanager.PlaySound("light");
        }
        if (Barravida.health <= 30.0f && Barravida.health >= 20.0f)
        {
            StaticManager.soundmanager.PlaySound("moderate");
        }
        if (Barravida.health <= 10.0f && Barravida.health >= 0.1f)
        {
            StaticManager.soundmanager.PlaySound("heavy");
        }
    }
   
   public void Puntuacion()
    {        
      contador++;
      hits.text= contador.ToString();
    }
}
