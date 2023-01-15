using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject playerUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] public static bool gamePaused = false;
    [SerializeField] private static bool shopPause = false;

    public static void pause()
    {
        gamePaused = true;
        Time.timeScale = 0;
    }

    public static void pauseForShop()
    {
        shopPause = true;
        gamePaused = true;
        Time.timeScale = 0;
    }

    public static void unpause()
    {
        shopPause = false;
        gamePaused = false;
        Time.timeScale = 1;
    }


    void Update()
    {
        shop.SetActive(shopPause);
        if (!shopPause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!gamePaused)
                {
                    pauseUI.SetActive(true);
                    pause();
                } else
                {
                    pauseUI.SetActive(false);
                    unpause();
                }
                return;
            }
        }
    }

}
