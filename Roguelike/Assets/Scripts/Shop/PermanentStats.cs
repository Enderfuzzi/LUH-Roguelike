using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PermanentStats : MonoBehaviour
{
    private static int damageBoost;
    public const int damageCost = 10;
    private static int healthBoost;
    public const int healthCost = 7;
    private static int movementBoost;
    public const int movementCost = 5;
    private static int damageResistanceBoost;
    public const int resistanceCost = 4;
    private static int projectileSpeedBoost;
    public const int projectileSpeedCost = 6;

    //Currencies
    private static int bronze;
    private static int silver;
    private static int gold;
    private static int crystal;

    private static bool created = false;

    void Start()
    {
        if (!created)
        {
            created = true; 
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        damageBoost = PlayerPrefs.GetInt("PlayerDamageBoost", 0);
        healthBoost = PlayerPrefs.GetInt("PlayerHealthBoost", 0);
        movementBoost = PlayerPrefs.GetInt("PlayerMovementBoost", 0);
        damageResistanceBoost = PlayerPrefs.GetInt("PlayerResistanceBoost", 0);
        projectileSpeedBoost = PlayerPrefs.GetInt("PlayerProjectileSpeedBoost", 0);


        bronze = PlayerPrefs.GetInt("CurrencyBronze", 0);
        silver = PlayerPrefs.GetInt("CurrencySilver", 0);
        gold = PlayerPrefs.GetInt("CurrencyGold", 0);
        crystal = PlayerPrefs.GetInt("CurrencyCrystal", 0);
    }

    void Awake()
    {
        /**
        damageBoost = PlayerPrefs.GetInt("PlayerDamageBoost", 0);
        healthBoost = PlayerPrefs.GetInt("PlayerHealthBoost", 0);
        movementBoost = PlayerPrefs.GetInt("PlayerMovementBoost", 0);
        damageResistanceBoost = PlayerPrefs.GetInt("PlayerResistanceBoost", 0);
        projectileSpeedBoost = PlayerPrefs.GetInt("PlayerProjectileSpeedBoost", 0);


        bronze = PlayerPrefs.GetInt("CurrencyBronze", 0);
        silver = PlayerPrefs.GetInt("CurrencySilver", 0);
        gold = PlayerPrefs.GetInt("CurrencyGold", 0);
        crystal = PlayerPrefs.GetInt("CurrencyCrystal", 0);
        */
    }

    public static void upgradeDamage()
    {
        if (damageBoost * damageCost <= bronze)
        {
            addBronze(damageBoost * damageCost * -1);
            damageBoost++;
            PlayerPrefs.SetInt("PlayerDamageBoost", damageBoost);
        }
    }

    public static void upgradeHealth()
    {
        if (healthBoost * healthCost <= silver)
        {
            addSilver(healthBoost * healthCost * -1);
            healthBoost++;
            PlayerPrefs.SetInt("PlayerHealthBoost", healthBoost);
        }
    }

    public static void upgradeMovement()
    {
        if (movementBoost * movementCost <= crystal) {
            addCrystal(movementBoost * movementCost * -1);
            movementBoost++;
            PlayerPrefs.SetInt("PlayerMovementBoost", movementBoost);
        }
    }

    public static void upgradeResistance()
    {
        if (damageResistanceBoost * resistanceCost <= silver)
        {
            addSilver(damageResistanceBoost * resistanceCost * -1);
            damageResistanceBoost++;
            PlayerPrefs.SetInt("PlayerResistanceBoost", damageResistanceBoost);
        }
    }

    public static void upgradeProjectileSpeed()
    {
        if (projectileSpeedBoost * projectileSpeedCost <= gold)
        {
            addGold(projectileSpeedBoost * projectileSpeedCost * -1);
            projectileSpeedBoost++;
            PlayerPrefs.SetInt("PlayerProjectileSpeedBoost", projectileSpeedBoost);
        }
    }

    public static int getDamageBoost()
    {
        return damageBoost * 5;
    }

    public static int getDamageBoostLevel()
    {
        return damageBoost;
    }

    public static int getHealthBoost()
    {
        return healthBoost * 10;
    }

    public static int getHealthBoostLevel()
    {
        return healthBoost;
    }

    public static float getMovementBoost()
    {
        return movementBoost * 2.0f;
    }

    public static int getMovementBoostLevel()
    {
        return movementBoost;
    }

    public static int getResistanceBoost()
    {
        return damageResistanceBoost * 2;
    }

    public static int getResistanceBoostLevel()
    {
        return damageResistanceBoost;
    }

    public static float getProjectileSpeedBoost()
    {
        return projectileSpeedBoost * 50.0f;
    }

    public static int getProjectileSpeedBoostLevel()
    {
        return projectileSpeedBoost;
    }

    public static void addBronze(int value)
    {
        bronze += value;
        PlayerPrefs.SetInt("CurrencyBronze", bronze);
    }

    public static void addSilver(int value)
    {
        silver += value;
        PlayerPrefs.SetInt("CurrencySilver", silver);
    }

    public static void addGold(int value)
    {
        gold += value;
        PlayerPrefs.SetInt("CurrencyGold", gold);
    }

    public static void addCrystal(int value)
    {
        crystal += value;
        PlayerPrefs.SetInt("CurrencyCrystal", crystal);
    }

    public static int getBronze()
    {
        return bronze;
    }

    public static int getSilver()
    {
        return silver;
    }

    public static int getGold()
    {
        return gold;
    }

    public static int getCrystal()
    {
        return crystal;
    }

    public static void save()
    {
        PlayerPrefs.Save();
    }

    public static void resetAll()
    {
        damageBoost = 0;
        healthBoost = 0;
        movementBoost = 0;
        damageResistanceBoost = 0;
        projectileSpeedBoost = 0;

        PlayerPrefs.SetInt("PlayerDamageBoost", damageBoost);
        PlayerPrefs.SetInt("PlayerHealthBoost", healthBoost);
        PlayerPrefs.SetInt("PlayerMovementBoost", movementBoost);
        PlayerPrefs.SetInt("PlayerResistanceBoost", damageResistanceBoost);
        PlayerPrefs.SetInt("PlayerProjectileSpeedBoost", projectileSpeedBoost);

        addBronze(bronze * -1);
        addSilver(silver * -1);
        addGold(gold * -1);
        addCrystal(crystal * -1);
        save();
    }

    void OnDestroy()
    {
        save();
    }

    void OnDisable()
    {
        save();
    }
}
