using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Escenas : MonoBehaviour
{
    public Text playerDisplay;

    private void Start()
    {
        if (DBManager.LoggedIn)
        {
            playerDisplay.text =  DBManager.username;
        }
    }
    public void GoToRegister()
    {
        SceneManager.LoadScene("Register");
    }
    public void GoToLogin()
    {
        SceneManager.LoadScene("Login");
    }
    public void GoToGame()
    {
        SceneManager.LoadScene("InGame");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToAccount()
    {
        SceneManager.LoadScene("Account");
    }
}
