using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Control : MonoBehaviour
{

    [SerializeField] public Rigidbody2D rb;
    //public CharacterController control;

    public Animator animator;

    private Vector3 velocity;

    //private bool touchRight = false;
    //private bool touchLeft = false;
    //private bool touchUp = false;
    //private bool touchDown = false;

    [SerializeField] private float speed = 5.0f;

    //private float diagonaleFactor = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /**
        control.Move(new Vector3(1, 1, 1));
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        control.Move(move * Time.deltaTime * speed);

        velocity.y = Time.deltaTime;
        control.Move(velocity * Time.deltaTime);
        */

        float horizontalMovement = Input.GetAxis("Horizontal") * speed;
        float verticalMovement = Input.GetAxis("Vertical") * speed;

        animator.SetFloat("ySpeed", verticalMovement);
        animator.SetFloat("xSpeed", horizontalMovement);

        rb.velocity = new Vector3(horizontalMovement, verticalMovement, 0);



    }
}
