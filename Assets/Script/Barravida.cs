using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class Barravida : NetworkBehaviour
{
    //Image healthbar;
    public const float maxHealth = 100f;
   [SyncVar(hook = "OnChangeHealth")] public float curretHealth = maxHealth;
    public Image healthbar;

    public void TakeDamage(float amount)
    {
        if (!isServer)
        {
            return;
        }

        curretHealth -= amount;
        if (curretHealth <= 0)
        {
            curretHealth = maxHealth;
            RpcRespawn();
        }
        

        //Playerdeath();
        //DamageSounds();
    }

    void OnChangeHealth(float vida)
    {
        healthbar.fillAmount = vida / maxHealth;
    }


    [ClientRpc]
    void RpcRespawn()
    {
        if(isLocalPlayer)
        {
            transform.position = Vector3.zero;
        }
    }
/*
    public void Playerdeath()
    {
        if (Barravida.health <= 0)
        {
            gameObject.SetActive(false);
           // UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");

        }*/
    }



