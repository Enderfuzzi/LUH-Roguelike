using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.transform.parent.GetComponent<Player>();

        if (player != null)
        {
            
        }
       
    }

}
