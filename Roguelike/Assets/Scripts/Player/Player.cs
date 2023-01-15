using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ILiving
{
    [SerializeField] PlayerController pc;
    [SerializeField] UI playerUI;

    // begin stats
    private int damage = 5;
    private int currentLife = 100;
    [SerializeField] private int maximalLife = 100;
    private float attackSpeed = 1.0f;
    private float movementSpeed = 5.0f;
    private int damageResistance = 1;
    private float lifesteal = 0.5f;
    private int level = 0;
    private int expierence = 0;
    private int levelBorder = 3;

    [SerializeField] private int bronze = 0;
    [SerializeField] private int silver = 0;
    [SerializeField] private int gold = 0;
    [SerializeField] private int crystal = 0;
    [SerializeField] private float projectilSpeed = 700.0f;

    void Start()
    {
        changeDamage(PermanentStats.getDamageBoost());
        changeMaximalLife(PermanentStats.getHealthBoost());
        changeMovementSpeed(PermanentStats.getMovementBoost());
        changeDamageResistance(PermanentStats.getResistanceBoost());

        changeProjectileSpeed(PermanentStats.getProjectileSpeedBoost());
        changeAttackSpeed(PermanentStats.getAttackSpeedBoost());
        changeLifesteal(PermanentStats.getLifestealBoost());

        playerUI.updateExperience(expierence, levelBorder);
        pc = GetComponent<PlayerController>();
    }
    /**
    void Awake()
    {
        changeDamage(PermanentStats.getDamageBoost());
        changeMaximalLife(PermanentStats.getHealthBoost());
        changeMovementSpeed(PermanentStats.getMovementBoost());
        changeDamageResistance(PermanentStats.getResistanceBoost());

        changeProjectileSpeed(PermanentStats.getProjectileSpeedBoost());
        changeAttackSpeed(PermanentStats.getAttackSpeedBoost());
        changeLifesteal(PermanentStats.getLifestealBoost());

        playerUI.updateExperience(expierence, levelBorder);
    }

    */
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

    public void makeDamage(int value)
    {
        changeCurrentLife((int) (value * lifesteal));
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

    public void changeProjectileSpeed(float value)
    {
        projectilSpeed += value;
    }

    public float getProjectileSpeed()
    {
        return projectilSpeed;
    }

    public int getLevel()
    {
        return level;
    }

    private void changeAttackSpeed(float value)
    {
        attackSpeed += attackSpeed * value;
        pc.setAttackAnimationSpeed(attackSpeed);
    }

    public void addExperience()
    {
        expierence++;
        if (expierence == levelBorder)
        {
            level++;
            expierence = 0;
            levelBorder += 1 * level;
            ShopManager.pauseForShop();
        }
        playerUI.updateExperience(expierence, levelBorder);
    }

    public void die()
    {

        PermanentStats.addBronze(bronze);
        PermanentStats.addSilver(silver);
        PermanentStats.addGold(gold);
        PermanentStats.addCrystal(crystal);

        LevelManager.showDied();
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
