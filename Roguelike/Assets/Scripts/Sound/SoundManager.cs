using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider soundMusicSlider;
    [SerializeField] private Slider soundEffectSlider;
    [SerializeField] private GameObject visibleMusicValue;
    [SerializeField] private GameObject visibleEffectValue;

    void Start()
    {
        soundMusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        soundEffectSlider.value = PlayerPrefs.GetFloat("SoundEffectVolume", 0.5f);
        Debug.Log(PlayerPrefs.GetFloat("MusicVolume", 0.5f));
        setEffectVolume(soundEffectSlider.value);
        setMusicVolume(soundMusicSlider.value);
        
    }

    public void setEffectVolume(float value)
    {
        audioMixer.SetFloat("Effects", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("SoundEffectVolume", value);
        PlayerPrefs.Save();
        visibleEffectValue.GetComponent<SliderValue>().updateField((int)(value * 10));
    } 

    public void setMusicVolume(float value)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save();
        visibleMusicValue.GetComponent<SliderValue>().updateField((int)(value * 10));
    }


}