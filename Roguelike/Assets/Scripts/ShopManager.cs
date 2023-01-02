using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject playerUI;

    [SerializeField] public static bool gamePaused = false;



    public static void pauseForShop()
    {
        gamePaused = true;
       //Time.timeScale = 0;
    }

    public static void unpause()
    {
        gamePaused = false;
        //Time.timeScale = 1;
    }

    void FixedUpdate()
    {
        shop.SetActive(gamePaused);
        playerUI.SetActive(!gamePaused);
    }

}
