using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    private Vector3 initalPosition;
    // Start is called before the first frame update
    void Start()
    {
        initalPosition = transform.position;
    }
    
    void FixedUpdate()
    {
        transform.position += Vector3.left * Screen.width / 1000.0f;
        Debug.Log("Position: " + transform.position);
        if (transform.position.x <= -1590.0f)
        {
            transform.position = initalPosition;
        }
    }
}
