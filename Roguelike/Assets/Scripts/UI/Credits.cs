using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    private Vector3 initalPosition;
    private float creditsWidth;


    void Start()
    {
        initalPosition = transform.position;
        creditsWidth = GetComponent<RectTransform>().rect.width;
    }
    
    void FixedUpdate()
    {
        transform.position += Vector3.left * Screen.width / 1000.0f;
        Debug.Log("Position: " + transform.position);
        if (transform.position.x <= initalPosition.x - creditsWidth - Screen.width)
        {
            transform.position = initalPosition;
        }
    }
}
