using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    private Vector3 initalPosition;
    private float creditsWidth;
    public bool reset = false;

    void Awake()
    {
        initalPosition = transform.position;
        creditsWidth = GetComponent<RectTransform>().rect.width;
    }
    
    void FixedUpdate()
    {
        transform.position += Vector3.left * Screen.width / 1000.0f;
        Debug.Log("current Position: " + transform.position);
        Debug.Log("Target: " + (transform.position.x + creditsWidth));
        if (reset)
        {
            transform.position = initalPosition;
            reset = false;
        }
    }
}
