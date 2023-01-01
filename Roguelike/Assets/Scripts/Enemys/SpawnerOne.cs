using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerOne : MonoBehaviour
{

    [SerializeField] private GameObject playerReference;
    [SerializeField] private GameObject enemy;

    [SerializeField] private GameObject firstTopSpawner;
    [SerializeField] private GameObject secondTopSpawner;
    [SerializeField] private GameObject rightSideSpawner;
    [SerializeField] private GameObject leftSideSpawner;


    [SerializeField] private float timeUntilNextSpawn = 0f;
    private float spawnCooldown = 20f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        timeUntilNextSpawn -= Time.fixedDeltaTime;
        if (timeUntilNextSpawn <= 0.0f)
        {
            spawn();
            timeUntilNextSpawn = spawnCooldown;
        }
    }


    private void spawn()
    {
        int random = Random.Range(1, 5);
        switch (random)
        {
            case 1:
                spawnEnemy(firstTopSpawner.transform.position);
                break;
            case 2:
                spawnEnemy(secondTopSpawner.transform.position);
                break;
            case 3:
                spawnEnemy(leftSideSpawner.transform.position);
                break;
            case 4:
                spawnEnemy(rightSideSpawner.transform.position);
                break;
        }
    }

    private void spawnEnemy(Vector3 position)
    {
       GameObject spawnedEnemy = Instantiate(enemy, position, Quaternion.Euler(0, 0, 0));
       spawnedEnemy.GetComponent<EnemyController>().setPlayerReference(playerReference);
    }


}
