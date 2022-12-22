using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMage : MonoBehaviour, ILiving
{
    [SerializeField] private float damage = 1.0f;
    [SerializeField] private float currentLife = 5.0f;
    [SerializeField] private float maximalLife = 5.0f;
    [SerializeField] private float attackSpeed = 1.0f;
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private float damageResistance = 1.0f;

    [SerializeField] private float statModifier = 1.0f;
    [SerializeField] public float testfield = 1.0f;

    public void takeDamage(float value)
    {
        testfield += value;
        changeCurrentLife(-1.0f * value * (1.0f - damageResistance / 100.0f));
    }

    public void updateStatModifier(float value)
    {
        if (value > 0.0f)
        {
            statModifier = value;
        } 
    }

    public float getDamage()
    {
        return damage;
    }

    public void changeDamage(float value)
    {
        damage += value;
    }

    public float getCurrentLife()
    {
        return currentLife;
    }

    public void changeCurrentLife(float value) 
    {
        currentLife += Mathf.Round(value);
        if (currentLife > maximalLife) currentLife = maximalLife;
        if (currentLife <= 0.0f) die();
    }

    public float getMaximalLife()
    {
        return maximalLife; 
    }

    public void changeMaximalLife(float value)
    {
        maximalLife += value;
    }

    public float getMovementSpeed()
    {
        return movementSpeed;
    }

    public void changeMovementspeed(float value)
    {
        movementSpeed += value;
    }

    public void changeDamageResistance(float value)
    {
        damageResistance += value;
    }

    public void die()
    {
        Destroy(gameObject);
    }

}
