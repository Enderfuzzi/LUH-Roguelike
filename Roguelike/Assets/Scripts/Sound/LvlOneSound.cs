using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlOneSound : MonoBehaviour
{


    public static bool inGame = false;
    public static bool musicPlaying = false;
    private static bool wasPaused = false;

    private AudioSource music;

    void Start()
    {
        music = GameObject.FindWithTag("Sound").transform.GetChild(1).GetComponent<AudioSource>();
    }



    void Update()
    {

        if (inGame && !musicPlaying && !ShopManager.gamePaused)
        {
            music.Play();
            musicPlaying = true;
        } 
        else if (!inGame)
        {
            music.Stop();
        }
        else if (ShopManager.gamePaused)
        {
            music.Pause();
            wasPaused = true;
        }
        else if (!ShopManager.gamePaused && wasPaused)
        {
            music.UnPause();
            wasPaused = false;
        }

    }
}
