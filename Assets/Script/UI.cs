using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UI : MonoBehaviour
{
    public static int scoreValue = 0;
    Text hits;
    // Start is called before the first frame update
    void Start()
    {
        hits = GetComponent<Text>();
      
    }

    // Update is called once per frame
    void Update()
    {
        hits.text = scoreValue.ToString();
      
    }
    
}
