using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] private int damage = 0;
    [SerializeField] private Player player = null;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ILiving livingObject = collision.gameObject.transform.parent.GetComponent<ILiving>();

        if (!ShopManager.gamePaused)
        {
            if (livingObject != null)
            {
                livingObject.takeDamage(damage);
                if (player != null)
                {
                    player.makeDamage(damage);
                }
            }

        }
        this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        animator.SetTrigger("hitObject");
        Destroy(gameObject, 1);
    }

    public void setDamage(int value)
    {
        this.damage = value;
    }

    public void setPlayer(Player player)
    {
        this.player = player;   
    }

    public void DestroyAfterImpact()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }


}
