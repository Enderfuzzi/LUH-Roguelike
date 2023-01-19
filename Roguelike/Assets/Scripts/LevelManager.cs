using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static void showMainMenu()
    {
        Time.timeScale = 1;
        MenuSound.inMenu = true;
        LvlOneSound.inGame = false;
        SceneManager.LoadScene("MainMenu");
    }

    public static void StartLevelOne()
    {
        MenuSound.inMenu = false;
        LvlOneSound.inGame = true;
        SceneManager.LoadScene("lvlOne");
    }

    public static void showShop()
    {
        SceneManager.LoadScene("ShopMenu");
    }

    public static void showSettings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public static void showCredits()
    {
        SceneManager.LoadScene("CreditsMenu");
    }

    public static void showDied()
    {
        LvlOneSound.inGame = false;
        SceneManager.LoadScene("Died");
    }

    public static void exit()
    {
        Application.Quit();
    }

}
