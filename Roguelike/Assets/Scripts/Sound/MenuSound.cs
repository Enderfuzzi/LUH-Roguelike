using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuSound : MonoBehaviour
{
    public static bool first = true;
    public static bool inMenu = true;
    private static bool running = false;
    [SerializeField] private AudioSource menuSound;
    [SerializeField] private AudioMixer audioMixer;

    void Start()
    {
        if (first)
        {
            DontDestroyOnLoad(this.gameObject);
            first = false;
            Debug.Log(PlayerPrefs.GetFloat("MusicVolume", 5f));
            audioMixer.SetFloat("Music", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume", 5f)) * 20);
            audioMixer.SetFloat("Effects", Mathf.Log10(PlayerPrefs.GetFloat("SoundEffectVolume", 5f)) * 20);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        if (!inMenu)
        {
            menuSound.Stop();
            running = false;
        }

        if (inMenu && !running)
        {
            menuSound.Play();
            running = true;
        }
    }
}
