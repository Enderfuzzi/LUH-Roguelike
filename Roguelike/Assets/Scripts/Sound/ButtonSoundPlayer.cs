using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundPlayer : MonoBehaviour
{
    public void play()
    {
        GameObject.FindWithTag("Sound").transform.GetChild(0).GetComponent<AudioSource>().Play();
    }
}
