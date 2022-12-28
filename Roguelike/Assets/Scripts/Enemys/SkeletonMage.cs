using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMage : MonoBehaviour, ILiving
{
    [SerializeField] private int damage = 10;
    [SerializeField] private int currentLife = 20;
    [SerializeField] private int maximalLife = 20;
    [SerializeField] private float attackSpeed = 1.0f;
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private int damageResistance = 1;

    [SerializeField] private int statModifier = 1;

    //Drops
    [SerializeField] private GameObject bronze;
    [SerializeField] private GameObject silver;
    [SerializeField] private GameObject gold;
    [SerializeField] private GameObject crystal;

    public void takeDamage(int value)
    {
        changeCurrentLife(-1 * (value - 1));
    }

    public void updateStatModifier(int value)
    {
        if (value > 0)
        {
            statModifier = value;
        } 
    }

    public int getDamage()
    {
        return damage;
    }

    public void changeDamage(int value)
    {
        damage += value;
    }

    public int getCurrentLife()
    {
        return currentLife;
    }

    public void changeCurrentLife(int value) 
    {
        currentLife += value;
        if (currentLife > maximalLife) currentLife = maximalLife;
        if (currentLife <= 0) die();
    }

    public float getMaximalLife()
    {
        return maximalLife; 
    }

    public void changeMaximalLife(int value)
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

    public void changeDamageResistance(int value)
    {
        damageResistance += value;
    }

    public void die()
    {
        int random = Random.Range(1, 101);
        if (random <= 50)
        {
            for (int i = 0; i < Random.Range(3, 6); i++)
            {
                    Instantiate(bronze, randomVector(), Quaternion.Euler(0, 0, 0));
            }
        }
        else if (random <= 80)
        {
            for (int i = 0; i < Random.Range(1, 6); i++)
            {
                Instantiate(silver, randomVector(), Quaternion.Euler(0, 0, 0));
            }
        }
        else if (random <= 95)
        {
            for (int i = 0; i < Random.Range(1, 5); i++)
            {
                Instantiate(gold, randomVector(), Quaternion.Euler(0, 0, 0));
            }
        }
        else
        {
            for (int i = 0; i < Random.Range(1, 3); i++)
            {
                Instantiate(crystal, randomVector(), Quaternion.Euler(0, 0, 0));
            }
        }
        Destroy(gameObject);
    }


    private Vector3 randomVector()
    {
        return transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-1.0f, -0.76f), 0);
    }

}
