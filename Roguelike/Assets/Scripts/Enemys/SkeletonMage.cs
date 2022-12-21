using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMage : MonoBehaviour
{
    [SerializeField] private float damage = 1.0f;
    [SerializeField] private float currentLife = 5.0f;
    [SerializeField] private float maximalLife = 5.0f;
    [SerializeField] private float attackSpeed = 1.0f;
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private float damageResistance = 1.0f;

    [SerializeField] private float statModifier = 1.0f;


    public void updateStatModifier(float value)
    {
        if (value > 0.0f)
        {
            statModifier = value;
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
