using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField InputUserN;
    public InputField InputPass;

    public Button SubmitButton;

    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", InputUserN.text);
        form.AddField("password", InputPass.text);
        WWW www = new WWW("https://unitestsoren.000webhostapp.com/login.php", form);
        yield return www;

        if(www.text[0]=='0')
        {
            DBManager.username = InputUserN.text;
            DBManager.score = int.Parse(www.text.Split('\t')[1]);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("Login ha fallado... Error #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        SubmitButton.interactable = (InputUserN.text.Length >= 0 && InputPass.text.Length >= 0);

    }
}
