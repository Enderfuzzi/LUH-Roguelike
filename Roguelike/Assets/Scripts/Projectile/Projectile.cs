using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] private float damage = 0.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ILiving livingObject = collision.gameObject.GetComponent<ILiving>();

        if (livingObject != null)
        {
            livingObject.takeDamage(damage);
        }

        this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        animator.SetTrigger("hitObject");
    }

    public void setDamage(float value)
    {
        this.damage = value;
    }

    public void DestroyAfterImpact()
    {
        Destroy(gameObject);
    }


}
