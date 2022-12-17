using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        animator.SetTrigger("hitObject");
    }

    public void DestroyAfterImpact()
    {
        Destroy(gameObject);
    }


}
