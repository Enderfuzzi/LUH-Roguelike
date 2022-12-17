using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerController pc;

    // begin stats
    [SerializeField] private float damage = 1.0f;
    [SerializeField] private float life = 1.0f;
    [SerializeField] private float attackSpeed = 1.0f;
    [SerializeField] private float movementSpeed = 1.0f;
    [SerializeField] private float armor = 1.0f;
    [SerializeField] private float lifesteal = 1.0f;
    [SerializeField] private int level = 0;






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
