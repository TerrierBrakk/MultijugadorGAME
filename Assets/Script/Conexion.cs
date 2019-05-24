using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conexion : MonoBehaviour
{
    public InputField InputUserN;
    public InputField InputPass;

    public Button SubmitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", InputUserN.text);
        form.AddField("password", InputPass.text);
        WWW www = new WWW("https://unitestsoren.000webhostapp.com/registry.php",form);
         yield return www; 
        if(www.text == "0")
        {
            Debug.Log("Usuario Creado Correctamente");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("Usuario... Cagado no entro jajaj . Error#" + www.text);
        }
    }

    public void VerifyInputs()
    {
        SubmitButton.interactable = (InputUserN.text.Length >= 0 && InputPass.text.Length >= 0);

    }
}