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
    [SerializeField] private float spawnCooldown = 20f;
    [SerializeField] private int spawnedEnemyCount = 0;
    [SerializeField] private int numberOfSpawns = 1;

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
        if (ShopManager.gamePaused)
        {
            return;
        }

        timeUntilNextSpawn -= Time.fixedDeltaTime;
        if (timeUntilNextSpawn <= 0.0f)
        {
            int random = Random.Range(1, numberOfSpawns + 1);
            for (int i = 0; i < random; i++)
            {
                spawn();
                timeUntilNextSpawn = spawnCooldown;
            }
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
        increaseSpawnedEnemy();
    }

    private void increaseSpawnedEnemy()
    {
        spawnedEnemyCount++;
        if (spawnedEnemyCount % 10 == 0)
        {
            numberOfSpawns++;
        }

        if (spawnedEnemyCount % 7 == 0)
        {
            if (spawnCooldown > 6.0f)
            {
                spawnCooldown = spawnCooldown * 0.85f;
            }
        }
    }
}
