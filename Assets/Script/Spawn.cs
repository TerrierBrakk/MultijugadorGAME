using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawn : NetworkBehaviour
{
    public float rate;
    public GameObject[] enemigos;
    public int oleada = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemigo", rate, rate);
    }

    void SpawnEnemigo()
    {
        for(int i=0;i<oleada;i++)
        Instantiate(enemigos[(int)Random.Range(0, enemigos.Length)], new Vector3(Random.Range(-8.5f,8.5f),7,0),Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
