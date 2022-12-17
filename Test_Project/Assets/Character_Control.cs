using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Control : MonoBehaviour
{

    [SerializeField] public Rigidbody2D rb;
    //public CharacterController control;

    public Animator animator;

    [SerializeField] public GameObject projectile;

    private Vector3 velocity;

    //private bool touchRight = false;
    //private bool touchLeft = false;
    //private bool touchUp = false;
    //private bool touchDown = false;
    [SerializeField] private bool shoting = false;
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
        animator.ResetTrigger("Fire");
        if (Input.GetKeyDown("e"))
        { 
            animator.SetTrigger("Fire");
            shoting = true;
        }
        
  


            float verticalMovement = Input.GetAxis("Vertical");
            float horizontalMovement = Input.GetAxis("Horizontal");

        

        if (verticalMovement != 0) horizontalMovement = 0;

        if (verticalMovement != 0 || horizontalMovement != 0)
            {
                animator.SetFloat("yDirection", verticalMovement);
                animator.SetFloat("xDirection", horizontalMovement);
            }

            animator.SetFloat("ySpeed", verticalMovement);
            animator.SetFloat("xSpeed", horizontalMovement);

        if (shoting)
        {
            verticalMovement *= 0.25f;
            horizontalMovement *= 0.25f;
        }

        rb.velocity = new Vector3(horizontalMovement, verticalMovement, 0) * speed;


        
    }


    void shot_finished()
    {
        shoting = false;
        GameObject tmp = Instantiate(projectile, rb.position + new Vector2(1f, 2f), transform.rotation);
        tmp.transform.Rotate(0, 0, 0);
        //tmp.GetComponent<Ridigbody2D>().position = 
        tmp.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(20000.0f * Time.deltaTime, 0, 0));
    }

    void shoot()
    {
        GameObject tmp = Instantiate(projectile, rb.position + new Vector2(1f, 2f), transform.rotation);
        tmp.transform.Rotate(0, 0, 0);
        //tmp.GetComponent<Ridigbody2D>().position = 
        tmp.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(20000.0f * Time.deltaTime, 0, 0));
    }

}
