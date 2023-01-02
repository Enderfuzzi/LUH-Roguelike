using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;

    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private float attackAnimationSpeed = 1.0f;

    [SerializeField] public Animator animator;

    [SerializeField] private GameObject playerReference;

    private Vector3 velocity;

    private float playerDisplacement = 0.65f;
    private float verticalDisplacement = 0.975f;
    private float horizontalDisplacement = 0.5f;

    private LayerMask playerHitboxMask;
    private LayerMask projectileHitboxMask;

    private bool leavedSpawn = true;

    // Start is called before the first frame update
    void Start()
    {

        playerHitboxMask = LayerMask.GetMask("Player_Target");
        projectileHitboxMask = LayerMask.GetMask("Enviroment_Projectile_Hitbox");


        this.setAttackAnimationSpeed(attackAnimationSpeed);
        this.setMovementSpeed(movementSpeed);

        animator.SetFloat("yDirection", -1.0f);
        animator.SetFloat("xDirection", 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerReference == null)
        {
            return;
        }
        if (ShopManager.gamePaused)
        {
            return;
        }


        float horizontalMovement = 0;
        float verticalMovement = 0;
 
        animator.ResetTrigger("attackAnimation");
        if (!leavedSpawn)
        {





        }
        else
        {
            if (!shoot())
            {
                bool verticalPath;
                bool horizontalPath;
                bool shootableVertical = false;
                bool shootableHorizontal = false;

                float verticalDistance = playerReference.transform.position.y + playerDisplacement - transform.position.y;
                float horizontalDistance = playerReference.transform.position.x - transform.position.x;
                //Debug.Log("Vertical Distance: " + verticalDistance);
               // Debug.Log("Horizontal Distance: " + horizontalDistance);
                //Check if both path are avaible
                if (transform.position.y < playerReference.transform.position.y)
                {
                    verticalPath = walkable(new Vector3(transform.position.x + horizontalDisplacement, transform.position.y, 0), Vector2.up, Mathf.Abs(verticalDistance));
                    verticalPath = verticalPath && walkable(new Vector3(transform.position.x - horizontalDisplacement, transform.position.y, 0), Vector2.up, Mathf.Abs(verticalDistance));
                }
                else if (transform.position.y > playerReference.transform.position.y)
                {
                    verticalPath = walkable(new Vector3(transform.position.x + horizontalDisplacement, transform.position.y, 0), Vector2.down, Mathf.Abs(verticalDistance));
                    verticalPath = verticalPath && walkable(new Vector3(transform.position.x - horizontalDisplacement, transform.position.y, 0), Vector2.down, Mathf.Abs(verticalDistance));
                }
                else
                {
                    verticalPath = true;
                }

                //Debug.Log("Vertical Path: " + verticalPath);
                if (transform.position.x < playerReference.transform.position.x)
                {
                    horizontalPath = walkable(new Vector3(transform.position.x, transform.position.y - verticalDisplacement, 0), Vector2.right, Mathf.Abs(horizontalDistance));
                    horizontalPath = horizontalPath && walkable(new Vector3(transform.position.x, transform.position.y - verticalDisplacement + 0.2f, 0), Vector2.right, Mathf.Abs(horizontalDistance));
                }
                else if (transform.position.x > playerReference.transform.position.x)
                {
                    horizontalPath = walkable(new Vector3(transform.position.x, transform.position.y - verticalDisplacement, 0), Vector2.left, Mathf.Abs(horizontalDistance));
                    horizontalPath = horizontalPath && walkable(new Vector3(transform.position.x, transform.position.y - verticalDisplacement + 0.2f, 0), Vector2.left, Mathf.Abs(horizontalDistance));
                }
                else
                {
                    horizontalPath = true;
                }
                //Debug.Log("horizontal Path: " + horizontalPath);

                if (horizontalPath)
                {
                    RaycastHit2D up = shootable(new Vector3(playerReference.transform.position.x, transform.position.y, 0), Vector2.up, Mathf.Abs(verticalDistance));
                    RaycastHit2D down = shootable(new Vector3(playerReference.transform.position.x, transform.position.y, 0), Vector2.down, Mathf.Abs(verticalDistance));
                    shootableHorizontal = up.collider == null || down.collider == null;
                }

                if (verticalPath)
                {
                    RaycastHit2D right = shootable(new Vector3(transform.position.x, playerReference.transform.position.y, 0), Vector2.right, Mathf.Abs(horizontalDistance));
                    RaycastHit2D left = shootable(new Vector3(transform.position.x, playerReference.transform.position.y, 0), Vector2.left, Mathf.Abs(horizontalDistance));
                    shootableVertical = right.collider == null || left.collider == null;
                }
                //Debug.Log("Shoot vertical: " + shootableVertical);
                //Debug.Log("Shoot horizontal: " + shootableHorizontal);
                if (!shootableVertical && !shootableHorizontal)
                {
                    Debug.Log("No option to Wlak");
                }

               // Debug.Log("Horizontal Path: " + horizontalPath);
                // if both path are avaible the path with the shortest distance is chosen 
                if (verticalPath && horizontalPath && shootableVertical && shootableHorizontal)
                {


                    if (Mathf.Abs(verticalDistance) < Mathf.Abs(horizontalDistance))
                    {
                        if (verticalDistance < 0)
                        {
                            verticalMovement = -1;
                        }
                        else
                        {
                            verticalMovement = 1;
                        }
                    }
                    else if (Mathf.Abs(verticalDistance) > Mathf.Abs(horizontalDistance))
                    {
                        if (horizontalDistance < 0)
                        {
                            horizontalMovement = -1;
                        }
                        else
                        {
                            horizontalMovement = 1;
                        }
                        // horizontalMovement = horizontalMovement / Mathf.Abs(horizontalMovement);
                    }
                    // Both Path have the same distance so choose a random path
                    else
                    {
                        if (Random.Range(1, 3) == 1)
                        {
                            if (verticalDistance < 0)
                            {
                                verticalMovement = -1;
                            }
                            else
                            {
                                verticalMovement = 1;
                            }

                            //verticalMovement = verticalDistance / Mathf.Abs(verticalDistance);
                        }
                        else
                        {
                            if (horizontalDistance < 0)
                            {
                                horizontalMovement = -1;
                            }
                            else
                            {
                                horizontalMovement = 1;
                            }
                            //horizontalMovement = horizontalMovement / Mathf.Abs(horizontalMovement);
                        }
                    }
                }
                else if (verticalPath && shootableVertical)
                {
                    if (verticalDistance < 0)
                    {
                        verticalMovement = -1;
                    }
                    else
                    {
                        verticalMovement = 1;
                    }
                    //verticalMovement = verticalDistance / Mathf.Abs(verticalDistance);
                }
                else if (horizontalPath && shootableHorizontal)
                {
                    if (horizontalDistance < 0)
                    {
                        horizontalMovement = -1;
                    }
                    else
                    {
                        horizontalMovement = 1;
                    }
                    //horizontalMovement = horizontalMovement / Mathf.Abs(horizontalMovement);
                }
                else
                {
                    if (horizontalPath)
                    {
                        if (horizontalDistance < 0)
                        {
                            horizontalMovement = 1;
                        }
                        else
                        {
                            horizontalMovement = -1;
                        }
                    }
                    if (verticalPath)
                    {
                        if (horizontalDistance < 0)
                        {
                            verticalMovement = 1;
                        }
                        else
                        {
                            verticalMovement = -1;
                        }
                    }

                }
            }
        }
        //Debug.Log("Vertical Movement: " + verticalMovement);
        //Debug.Log("Horizontal Movement: " + horizontalMovement);

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

    }

    void Awake()
    {

    }

    public void setPlayerReference(GameObject player)
    {
        playerReference = player;
    }


    private bool shoot()
    {

        //Debug.DrawRay(transform.position, new Vector3(35.0f, 0, 0), Color.yellow);
        //Debug.DrawRay(transform.position, new Vector3(-35.0f, 0, 0), Color.yellow);
        //Debug.DrawRay(transform.position, new Vector3(0, 35.0f, 0), Color.yellow);
        //Debug.DrawRay(transform.position, new Vector3(0, -35.0f, 0), Color.yellow);
        if (attack(Vector2.right))
        {
            return true;
        }
        if (attack(Vector2.left))
        {
            return true;    
        }
        
        if (attack(Vector2.up))
        {
            return true;
        }
        if (attack(Vector2.down))
        {
            return true;
        }
        return false;
    }

    private bool attack(Vector2 direction)
    {

        RaycastHit2D playerHit = inSight(transform.position, direction);
        if (playerHit.collider != null)
        {
            RaycastHit2D wallHit = shootable(transform.position, direction, playerHit.distance);
            if (wallHit.collider == null)
            {
                Debug.Log("Ray hit: " + playerHit.collider.gameObject + " at " + playerHit.point);

                animator.SetFloat("yDirection", direction.y);
                animator.SetFloat("xDirection", direction.x);

                animator.SetTrigger("attackAnimation");
                return true;
            }
        }
        return false;
       
    }

    private RaycastHit2D inSight(Vector3 position, Vector2 direction)
    {
        Debug.DrawRay(position, direction * 35.0f, Color.yellow);
        return Physics2D.Raycast(position, direction, 35.0f, playerHitboxMask.value);
    }

    private RaycastHit2D shootable(Vector3 position, Vector2 direction,float distance)
    {
        Debug.DrawRay(position, direction * distance, Color.red);
        return Physics2D.Raycast(position, direction, distance, projectileHitboxMask);
    }


    private bool walkable(Vector3 position,Vector2 direction, float distance)
    {
        LayerMask enviromentHitbox = LayerMask.GetMask("Enviroment");
        Debug.DrawRay(position, direction * distance, Color.yellow);
        RaycastHit2D terrainHit = Physics2D.Raycast(position, direction, distance, enviromentHitbox);
        return terrainHit.collider == null;
    }

}
