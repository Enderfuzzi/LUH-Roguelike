using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMage : MonoBehaviour, ILiving
{
    private EnemyController ec;

    private int damage = 10;
    private int currentLife = 20;
    private int maximalLife = 20;
    private float attackSpeed = 1.0f;
    private float movementSpeed = 5.0f;
    private int damageResistance = 1;

    private int statModifier = 0;

    //Drops
    [SerializeField] private GameObject bronze;
    [SerializeField] private GameObject silver;
    [SerializeField] private GameObject gold;
    [SerializeField] private GameObject crystal;
    [SerializeField] private GameObject experience;

    void Awake()
    {
        ec = GetComponent<EnemyController>();
    }


    public void takeDamage(int value)
    {
        changeCurrentLife(-1 * (value - 1));
    }

    public void updateStatModifier(int value)
    {
        if (value > 0)
        {
            statModifier = value;
            changeDamage(5 * statModifier);
            changeMaximalLife(10 * statModifier);
            changeMovementspeed(statModifier);
            changeAttackSpeed(statModifier);
            changeDamageResistance(2 * statModifier);
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
        currentLife += value;
    }

    public float getMovementSpeed()
    {
        return movementSpeed;
    }

    public void changeMovementspeed(float value)
    {
        movementSpeed += value;
        ec.setMovementSpeed(movementSpeed);
    }

    public void changeAttackSpeed(float value)
    {
        attackSpeed += 0.1f * value;
        ec.setAttackAnimationSpeed(attackSpeed);
    }

    public void changeDamageResistance(int value)
    {
        damageResistance += value;
    }

    public void die()
    {
        int experienceAmount = Random.Range(1, 4) + 2 * statModifier;
        Debug.Log("Experience: " + experienceAmount);
        for (int i = 0;i < experienceAmount; i++)
        {
            Instantiate(experience, randomVector(), Quaternion.Euler(0, 0, 0));
        }



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

        gameObject.SetActive(false);
        Destroy(gameObject, 10);
    }


    private Vector3 randomVector()
    {
        return transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-1.0f, -0.76f), 0);
    }

}
