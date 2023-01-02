using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ILiving
{
    [SerializeField] PlayerController pc;
    [SerializeField] UI playerUI;

    // begin stats
    [SerializeField] private int damage = 5;
    [SerializeField] private int currentLife = 10000;
    [SerializeField] private int maximalLife = 10000;
    [SerializeField] private float attackSpeed = 1.0f;
    [SerializeField] private float movementSpeed = 1.0f;
    [SerializeField] private int damageResistance = 1;
    [SerializeField] private float lifesteal = 1.0f;
    [SerializeField] private int level = 0;
    [SerializeField] private int expierence = 0;
    [SerializeField] private int levelBorder = 10;

    [SerializeField] private int bronze = 0;
    [SerializeField] private int silver = 0;
    [SerializeField] private int gold = 0;
    [SerializeField] private int crystal = 0;

    void Start()
    {
        pc = GetComponent<PlayerController>();
    }

    void Awake()
    {
 
    }


    public int getDamage()
    {
        return damage;
    }

    public void changeDamage(int value)
    {
        damage += value;
        if (damage < 0) damage = 0;
    }
    
    public void takeDamage(int value)
    {
        changeCurrentLife(-1 * (value - 1));
    }

    public int getCurrentLife()
    {
        return currentLife;
    }

    public void changeCurrentLife(int value)
    {
        currentLife += value;
        if (currentLife > maximalLife) currentLife = maximalLife;
        playerUI.updateLife(currentLife,maximalLife);
        if (currentLife <= 0) die(); 
    }

    public float getMaximalLife()
    {
        return maximalLife;
    }

    public void changeMaximalLife(int value)
    {
        maximalLife += value;
        currentLife += value;
        if (maximalLife < 1) maximalLife = 1;
        playerUI.updateLife(currentLife,maximalLife);
    }

    public float getMovementSpeed()
    {
        return movementSpeed;
    }

    public void changeMovementSpeed(float value)
    {
        movementSpeed += value;
        if (movementSpeed < 1.0f) movementSpeed = 1.0f;
        pc.setMovementSpeed(movementSpeed);
    } 

    public int getDamageResistance()
    {
        return damageResistance;
    } 

    public void changeDamageResistance(int value)
    {
        damageResistance += value;
    }

    public float getLifeSteal()
    {
        return lifesteal;
    }

    public void changeLifesteal(float value)
    {
        lifesteal += value;
        if (lifesteal < 0.0f) lifesteal = 0.0f;
    }

    public int getLevel()
    {
        return level;
    }

    public void addExperience()
    {
        expierence++;
        if (expierence == levelBorder)
        {
            level++;
            expierence = 0;
            levelBorder += 10 * level;
            ShopManager.pauseForShop();
        }
        playerUI.updateExperience(expierence, levelBorder);
    }

    public void die()
    {
        Destroy(gameObject);
    }

    public void addBronze()
    {
        bronze++;
        playerUI.updateBronze(bronze);
    }

    public int getBronze()
    {
        return bronze;
    }

    public void addSilver()
    {
        silver++;
        playerUI.updateSilver(silver);
    }

    public int getSilver()
    {
        return silver;
    }

    public void addGold()
    {
        gold++;
        playerUI.updateGold(gold);
    }

    public int getGold()
    {
        return gold;
    }

    public void addCrystal()
    {
        crystal++;
        playerUI.updateCrystal(crystal);
    }

    public int getCrystal()
    {
        return crystal;
    }


}
