using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject projectileType;
    [SerializeField] private float projectileSpeed;


    private void launchProjectile(Vector2 spawnPosition, float rotation, Vector3 flyingDirection)
    {
        Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);
        GameObject projectile = Instantiate(projectileType, spawnPosition, spawnRotation);
        projectile.GetComponent<Projectile>().setDamage(this.GetComponent<Player>().getDamage());
        projectile.transform.Rotate(0, 0, rotation);
        projectile.GetComponent<Rigidbody2D>().AddRelativeForce(flyingDirection * projectileSpeed);
    }

    public void launchDownProjectile()
    {
        this.launchProjectile(GameObject.Find("/Player/Projectile_Launcher/Down_Launcher").transform.position, -90.0f, Vector3.down);
    }

    public void lauchUpProjectile()
    {
        this.launchProjectile(GameObject.Find("/Player/Projectile_Launcher/Up_Launcher").transform.position, 90.0f, Vector3.up);
    }

    public void launchLeftProjectile()
    {
        this.launchProjectile(GameObject.Find("/Player/Projectile_Launcher/Left_Launcher").transform.position, 180.0f, Vector3.left);
    }

    public void launchRightProjectile()
    {
        this.launchProjectile(GameObject.Find("/Player/Projectile_Launcher/Right_Launcher").transform.position, 0.0f, Vector3.right);
    }
}
