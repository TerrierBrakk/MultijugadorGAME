using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnerEnemigo : NetworkBehaviour
{
    public GameObject[] enemyPrefab;
    public int numberOfEnemies;

    public override void OnStartServer()
    {
       
            for (int i = 0; i < numberOfEnemies; i++)
                Instantiate(enemyPrefab[(int)Random.Range(0, enemyPrefab.Length)], new Vector3(Random.Range(-8.5f, 8.5f), 7, 0), Quaternion.identity);
        
    }
}
