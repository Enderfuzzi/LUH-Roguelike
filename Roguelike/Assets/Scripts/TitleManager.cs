using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    void FixedUpdate()
    {
        if (Input.anyKey || Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            GameObject.FindWithTag("Sound").transform.GetChild(0).GetComponent<AudioSource>().Play();
            LevelManager.showMainMenu();
        }
    }
}
