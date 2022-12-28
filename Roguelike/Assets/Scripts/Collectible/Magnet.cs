using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private bool active = false;
    private Rigidbody2D rigid;
    private GameObject playerReference;

    private void Awake()
    {
        rigid = GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!active)
        {
            playerReference = collision.gameObject;
        }
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            active = true;
        }

    }

    void FixedUpdate()
    {
        if (active)
        {
            if (rigid != null)
            {
                Vector3 target = (playerReference.transform.position - transform.position);
                //Debug.Log("Player: " + playerReference.GetComponent<Rigidbody2D>().transform.position);
                rigid.MovePosition(transform.position + (target * Time.fixedDeltaTime * speed));
            }
        }
    }
}
