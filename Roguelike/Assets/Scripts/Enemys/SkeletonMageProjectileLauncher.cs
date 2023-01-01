using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMageProjectileLauncher : MonoBehaviour
{

    [SerializeField] private GameObject up;
    [SerializeField] private GameObject down;
    [SerializeField] private GameObject right;
    [SerializeField] private GameObject left;




    [SerializeField] private GameObject projectileType;
    [SerializeField] private float projectileSpeed;

    private void launchProjectile(Vector2 spawnPosition, float rotation, Vector3 flyingDirection)
    {
        Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);
        GameObject projectile = Instantiate(projectileType, spawnPosition, spawnRotation);
        projectile.GetComponent<Projectile>().setDamage(this.GetComponent<SkeletonMage>().getDamage());
        projectile.transform.Rotate(0, 0, rotation);
        projectile.GetComponent<Rigidbody2D>().AddRelativeForce(flyingDirection * projectileSpeed);
    }

    public void launchDownProjectile()
    {
        this.launchProjectile(down.transform.position, -90.0f, Vector3.down);
    }

    public void lauchUpProjectile()
    {
        this.launchProjectile(up.transform.position, 90.0f, Vector3.up);
    }

    public void launchLeftProjectile()
    {
        this.launchProjectile(left.transform.position, 180.0f, Vector3.left);
    }

    public void launchRightProjectile()
    {
        this.launchProjectile(right.transform.position, 0.0f, Vector3.right);
    }
}

