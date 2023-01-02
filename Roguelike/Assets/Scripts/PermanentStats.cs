using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PermanentStats : MonoBehaviour
{
    private static int damageBoost;
    private static int healthBoost;
    private static int movementBoost;
    private static int damageResistanceBoost;

    public static int projectileSpeedBoost;


    // Start is called before the first frame update
    void Start()
    {
        damageBoost = PlayerPrefs.GetInt("PlayerDamageBoost", 0);
        healthBoost = PlayerPrefs.GetInt("PlayerHealthBoost", 0);
        movementBoost = PlayerPrefs.GetInt("PlayerMovementBoost", 0);
        damageResistanceBoost = PlayerPrefs.GetInt("PlayerResistanceBoost", 0);

        projectileSpeedBoost = PlayerPrefs.GetInt("PlayerProjectileSpeedBoost", 0);
    }

    public static void upgradeDamage()
    {
        damageBoost++;
    }

    public static void upgradeHealth()
    {
        healthBoost++;
    }

    public static void upgradeMovement()
    {
        movementBoost++;
    }

    public static void upgradeResistance()
    {
        damageResistanceBoost++;
    }

    public static void upgradeProjectileSpeed()
    {
        projectileSpeedBoost++;
    }

    public static int getDamageBoost()
    {
        return damageBoost * 5;
    }

    public static int getHealthBoost()
    {
        return healthBoost * 10;
    }

    public static float getMovementBoost()
    {
        return movementBoost * 2.0f;
    }

    public static int getResistanceBoost()
    {
        return damageResistanceBoost * 2;
    }

    public static float getProjectileSpeedBoost()
    {
        return projectileSpeedBoost * 50.0f;
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("PlayerDamageBoost", damageBoost);
        PlayerPrefs.SetInt("PlayerHealthBoost", healthBoost);
        PlayerPrefs.SetInt("PlayerMovementBoost",movementBoost);
        PlayerPrefs.SetInt("PlayerResistanceBoost", damageResistanceBoost);
        
        PlayerPrefs.SetInt("PlayerProjectileSpeedBoost", projectileSpeedBoost);
        PlayerPrefs.Save();
    }
}
