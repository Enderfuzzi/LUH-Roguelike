using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] private int damage = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        ILiving livingObject = collision.gameObject.transform.parent.GetComponent<ILiving>();

        if (livingObject != null)
        {
            livingObject.takeDamage(damage);
        }

        this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        animator.SetTrigger("hitObject");
    }

    public void setDamage(int value)
    {
        this.damage = value;
    }

    public void DestroyAfterImpact()
    {
        Destroy(gameObject);
    }


}
