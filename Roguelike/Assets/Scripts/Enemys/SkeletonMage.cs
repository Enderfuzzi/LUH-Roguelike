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

    //Drops
    [SerializeField] private GameObject bronze;
    [SerializeField] private GameObject silver;
    [SerializeField] private GameObject gold;
    [SerializeField] private GameObject crystal;

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

    [SerializeField] private LayerMask layermask;

    public void die()
    {
        int random = Random.Range(1, 101);
        if (random <= 100)
        {
            for (int i = 0; i < Random.Range(16, 32); i++)
            {
                Vector3 spawnPosition = randomVector();
                if (!Physics.CheckSphere(spawnPosition, 1f,layermask))
                {
                    Instantiate(bronze, spawnPosition, Quaternion.Euler(0, 0, 0));
                }
            }
        }
        else if (random <= 80)
        {
            for (int i = 0; i < Random.Range(8, 16); i++)
            {
                Instantiate(silver, transform.position * Random.Range(0.5f, 1.51f), Quaternion.Euler(0, 0, 0));
            }
        }
        else if (random <= 95)
        {
            for (int i = 0; i < Random.Range(4, 8); i++)
            {
                Instantiate(gold, transform.position * Random.Range(0.5f, 1.51f), Quaternion.Euler(0, 0, 0));
            }
        }
        else
        {
            for (int i = 0; i < Random.Range(1, 4); i++)
            {
                Instantiate(crystal, transform.position * Random.Range(0.5f, 1.51f), Quaternion.Euler(0, 0, 0));
            }
        }
        Destroy(gameObject);
    }


    private Vector3 randomVector()
    {
        return transform.position + new Vector3(Random.Range(-0.8f, 0.81f), Random.Range(-0.8f, 0.81f), 0);
    }

}
