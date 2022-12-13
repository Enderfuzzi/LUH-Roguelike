using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;

    [SerializeField] private float speed = 5.0f;

    private Vector3 velocity;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * speed;
        float verticalMovement = Input.GetAxis("Vertical") * speed;

        if (verticalMovement != 0) horizontalMovement = 0;

        animator.SetFloat("ySpeed", verticalMovement);
        animator.SetFloat("xSpeed", horizontalMovement);

        rb.velocity = new Vector3(horizontalMovement, verticalMovement, 0);
    }
}
