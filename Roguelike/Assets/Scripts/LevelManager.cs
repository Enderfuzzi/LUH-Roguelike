using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void showMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartLevelOne()
    {
        SceneManager.LoadScene("lvlOne");
    }

    public void showShop()
    {
        SceneManager.LoadScene("ShopMenu");
    }

    public void showSettings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void showCredits()
    {
        SceneManager.LoadScene("CreditsMenu");
    }

    public void exit()
    {
        Application.Quit();
    }

}
