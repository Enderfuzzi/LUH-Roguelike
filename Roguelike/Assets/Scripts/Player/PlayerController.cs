using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    [SerializeField] public Rigidbody2D rb;

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float attackAnimationSpeed = 1.0f;

    private Vector3 velocity;


    [SerializeField] public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.setAttackAnimationSpeed(attackAnimationSpeed);
        this.setMovementSpeed(speed);

        animator.SetFloat("yDirection", -1.0f);
        animator.SetFloat("xDirection", 0.0f);

        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!ShopManager.gamePaused)
        {



            animator.ResetTrigger("attackAnimation");
            if (Input.GetKeyDown("space"))
            {
                animator.SetTrigger("attackAnimation");
            }

            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");


            if (Mathf.Log(Mathf.Abs(verticalMovement), 3) >= Mathf.Log(Mathf.Abs(horizontalMovement), 3)) horizontalMovement = 0;
            else verticalMovement = 0;



            if (verticalMovement != 0 || horizontalMovement != 0)
            {
                animator.SetFloat("yDirection", verticalMovement);
                animator.SetFloat("xDirection", horizontalMovement);
            }

            animator.SetFloat("ySpeed", verticalMovement);
            animator.SetFloat("xSpeed", horizontalMovement);




            // Vector3 move = new Vector3(horizontalMovement, verticalMovement, 0) * speed * Time.deltaTime;
            // rb.velocity = move;
            rb.velocity = new Vector3(horizontalMovement, verticalMovement, 0) * speed;
        }
        else
        {
            animator.SetFloat("ySpeed", 0);
            animator.SetFloat("xSpeed", 0);
            rb.velocity = Vector3.zero;
        }
    }


    void fixedUpdate()
    {
        
    }

    public void setAttackAnimationSpeed(float animationSpeed)
    {
        animator.SetFloat("attackAnimationSpeed", animationSpeed);
    }

    public void setMovementSpeed(float movement_speed)
    {
        this.speed = movement_speed;
        animator.SetFloat("movementAnimationSpeed", speed / 5.0f);
    }

}
