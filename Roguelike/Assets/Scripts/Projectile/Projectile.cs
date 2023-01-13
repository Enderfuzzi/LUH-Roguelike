using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] private int damage = 0;
    [SerializeField] private Player player = null;
    private Vector3 relativeForce;
    private bool wasPaused = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ILiving livingObject = collision.gameObject.transform.parent.GetComponent<ILiving>();

        if (!ShopManager.gamePaused)
        {
            if (livingObject != null)
            {
                livingObject.takeDamage(damage);
            }

            if (player != null)
            {
                player.makeDamage(damage);
            }

        }
        this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        animator.SetTrigger("hitObject");
    }

    public void setDamage(int value)
    {
        this.damage = value;
    }

    public void setPlayer(Player player)
    {
        this.player = player;   
    }

    public void setRelativeForce(Vector3 value)
    {
        relativeForce = value;
    }
    void Start()
    {
        this.GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    void FixedUpdate()
    {
        if (ShopManager.gamePaused && !wasPaused)
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            animator.enabled = false;
            wasPaused = true;
        }
        else if (!ShopManager.gamePaused && wasPaused)
        {
            this.GetComponent<Rigidbody2D>().AddRelativeForce(relativeForce);
            animator.enabled = true;
            wasPaused = false;
        }
    }

    public void DestroyAfterImpact()
    {
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }


}
