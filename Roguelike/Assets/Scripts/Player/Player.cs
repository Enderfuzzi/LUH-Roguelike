using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ILiving
{
    [SerializeField] PlayerController pc;

    // begin stats
    [SerializeField] private float damage = 1.0f;
    [SerializeField] private float currentLife = 1.0f;
    [SerializeField] private float maximalLife = 1.0f;
    [SerializeField] private float attackSpeed = 1.0f;
    [SerializeField] private float movementSpeed = 1.0f;
    [SerializeField] private float damageResistance = 1.0f;
    [SerializeField] private float lifesteal = 1.0f;
    [SerializeField] private int level = 0;
    [SerializeField] private float expierence = 0.0f;
    [SerializeField] private float levelBorder = 10.0f;

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
        changeCurrentLife(value * (1 - damageResistance / 100));
    }

    public float getCurrentLife()
    {
        return currentLife;
    }

    public void changeCurrentLife(float value)
    {
        currentLife += value;
        if (currentLife > maximalLife) currentLife = maximalLife;
        if (currentLife <= 0.0f) ; //death here 
    }

    public float getMaximalLife()
    {
        return maximalLife;
    }

    public void changeMaximalLife(float value)
    {
        maximalLife += value;
        if (maximalLife < 1.0f) maximalLife = 1.0f;
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

    public void increaseExperience(float value)
    {
        expierence += value;
        if (expierence >= levelBorder)
        {
            level++;
            expierence -= levelBorder;
            levelBorder += 10 * level;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
