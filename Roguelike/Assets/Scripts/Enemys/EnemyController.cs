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
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        if (Mathf.Log(Mathf.Abs(verticalMovement), 3) >= Mathf.Log(Mathf.Abs(horizontalMovement), 3)) horizontalMovement = 0;
        else verticalMovement = 0;


        animator.ResetTrigger("attackAnimation");
        LayerMask mask = LayerMask.GetMask("Player_Hitbox");

        Debug.DrawRay(transform.position, new Vector3(35.0f, 0, 0), Color.yellow);
        Debug.DrawRay(transform.position, new Vector3(-35.0f, 0, 0), Color.yellow);
        Debug.DrawRay(transform.position, new Vector3(0, 35.0f, 0), Color.yellow);
        Debug.DrawRay(transform.position, new Vector3(0, -35.0f, 0), Color.yellow);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(1, 0), 35.0f, mask.value);
        if (hit.collider != null)
        {
            Debug.Log("Ray hit: " + hit.collider.gameObject + " at " + hit.point);

            animator.SetFloat("yDirection", 0);
            animator.SetFloat("xDirection", 1);

            animator.SetTrigger("attackAnimation");
        }
         hit = Physics2D.Raycast(transform.position, new Vector2(-1, 0), 35.0f, mask.value);
        if (hit.collider != null)
        {
            Debug.Log("Ray hit: " + hit.collider.gameObject + " at " + hit.point);

            animator.SetFloat("yDirection", 0);
            animator.SetFloat("xDirection", -1);

            animator.SetTrigger("attackAnimation");
        }
        hit = Physics2D.Raycast(transform.position, new Vector2(0, 1), 35.0f, mask.value);
        if (hit.collider != null)
        {
            Debug.Log("Ray hit: " + hit.collider.gameObject + " at " + hit.point);

            animator.SetFloat("yDirection", 1);
            animator.SetFloat("xDirection", 0);

            animator.SetTrigger("attackAnimation");
        }
         hit = Physics2D.Raycast(transform.position, new Vector2(0, -1), 35.0f, mask.value);
        if (hit.collider != null)
        {
            Debug.Log("Ray hit: " + hit.collider.gameObject + " at " + hit.point);

            animator.SetFloat("yDirection", -1);
            animator.SetFloat("xDirection", 0);

            animator.SetTrigger("attackAnimation");
        }




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

    void FixedUpdate()
    {
        LayerMask mask = LayerMask.GetMask("Player_Hitbox");
        //RaycastHit hit;
        Debug.DrawRay(transform.position, new Vector3(35.0f, 0, 0), Color.yellow);
        //Debug.DrawRay(transform.position, new Vector3(-35, 0, 0), Color.yellow);
        //Debug.DrawRay(transform.position, new Vector3(0, 35, 0), Color.green);
        //Debug.DrawRay(transform.position, new Vector3(0, -35, 0), Color.green);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(1,0),35.0f,mask.value);
        if (hit.collider != null)
        {
            Debug.Log("Ray hit: " + hit.collider.gameObject + " at " + hit.point);
            animator.SetTrigger("attackAnimation");
        }
    }



    private void shoot()
    {

    }


}
