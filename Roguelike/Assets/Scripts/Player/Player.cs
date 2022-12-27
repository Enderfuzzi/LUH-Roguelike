using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ILiving
{
    [SerializeField] PlayerController pc;
    [SerializeField] UI playerUI;

    // begin stats
    [SerializeField] private float damage = 1.0f;
    [SerializeField] private float currentLife = 1.0f;
    [SerializeField] private float maximalLife = 1.0f;
    [SerializeField] private float attackSpeed = 1.0f;
    [SerializeField] private float movementSpeed = 1.0f;
    [SerializeField] private float damageResistance = 1.0f;
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

    }

    public float getDamage()
    {
        return damage;
    }

    public void changeDamage(float value)
    {
        damage += value;
        if (damage < 0.0f) damage = 0.0f;
    }
    
    public void takeDamage(float value)
    {
        changeCurrentLife(-1 * value * (1 - damageResistance / 100));
    }

    public float getCurrentLife()
    {
        return currentLife;
    }

    public void changeCurrentLife(float value)
    {
        currentLife += value;
        if (currentLife > maximalLife) currentLife = maximalLife;
        playerUI.updateLife((int) currentLife, (int) maximalLife);
        if (currentLife <= 0.0f) die(); 
    }

    public float getMaximalLife()
    {
        return maximalLife;
    }

    public void changeMaximalLife(float value)
    {
        maximalLife += value;
        if (maximalLife < 1.0f) maximalLife = 1.0f;
        playerUI.updateLife((int) currentLife,(int) maximalLife);
    }

    public float getMovementSpeed()
    {
        return movementSpeed;
    }

    public void changeMovementSpeed(float value)
    {
        movementSpeed += value;
        if (movementSpeed < 1.0f) movementSpeed = 1.0f; 
    } 

    public float getDamageResistance()
    {
        return damageResistance;
    } 

    public void changeDamageResistance(float value)
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
