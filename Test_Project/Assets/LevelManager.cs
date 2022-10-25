using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("Level_One");
    }

    public void StartMainMenue()
    {
        SceneManager.LoadScene("Main_Menue");
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
