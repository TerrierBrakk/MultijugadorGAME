using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class vidas : MonoBehaviour
{

    public static int lifes = 3;
    Text life_text;
    // Start is called before the first frame update
    void Start()
    {
        life_text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        life_text.text = lifes.ToString();

    }
}
