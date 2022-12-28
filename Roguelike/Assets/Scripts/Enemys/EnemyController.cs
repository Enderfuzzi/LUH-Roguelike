using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;

    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private float attackAnimationSpeed = 1.0f;

    [SerializeField] public Animator animator;

    [SerializeField] private LayerMask layerMask;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        this.setAttackAnimationSpeed(attackAnimationSpeed);
        this.setMovementSpeed(movementSpeed);

        animator.SetFloat("yDirection", -1.0f);
        animator.SetFloat("xDirection", 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        animator.ResetTrigger("attackAnimation");

        RaycastHit hit;
        Debug.DrawRay(transform.position, new Vector3(35, 0, 0), Color.yellow);
        Debug.DrawRay(transform.position, new Vector3(-35, 0, 0), Color.yellow);
        Debug.DrawRay(transform.position, new Vector3(0, 35, 0), Color.green);
        Debug.DrawRay(transform.position, new Vector3(0, -35, 0), Color.green);
        // if (Physics.Raycast(transform.position, new Vector3(1, 0, 0), out hit, layerMask))
        //  { 
        //     Debug.DrawRay(transform.position, new Vector3(1, 0, 0), Color.yellow);
        //  }

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

        rb.velocity = new Vector3(horizontalMovement, verticalMovement, 0) * movementSpeed;
    }

    void setAttackAnimationSpeed(float animationSpeed)
    {
        animator.SetFloat("attackAnimationSpeed", animationSpeed);
    }

    void setMovementSpeed(float movementSpeed)
    {
        this.movementSpeed = movementSpeed;
        animator.SetFloat("movementAnimationSpeed", this.movementSpeed / 5.0f);
    }

    private void shoot()
    {

    }


}
