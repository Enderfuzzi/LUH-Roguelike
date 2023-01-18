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


     private float timeUntilNextSpawn = 0f;
     private float spawnCooldown = 10f;
     private int spawnedEnemyCount = 0;
     private int numberOfSpawns = 1;
     private int lvlborder = 0;
     private int lvlIncrease = 5;

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
                spawn(Random.Range(0,lvlborder));
                timeUntilNextSpawn = spawnCooldown;
            }
        }
    }


    private void spawn(int modifier)
    {
        int random = Random.Range(1, 5);
        switch (random)
        {
            case 1:
                spawnEnemy(firstTopSpawner.transform.position, modifier);
                break;
            case 2:
                spawnEnemy(secondTopSpawner.transform.position, modifier);
                break;
            case 3:
                spawnEnemy(leftSideSpawner.transform.position, modifier);
                break;
            case 4:
                spawnEnemy(rightSideSpawner.transform.position, modifier);
                break;
        }
    }

    private void spawnEnemy(Vector3 position, int modifier)
    {
       GameObject spawnedEnemy = Instantiate(enemy, position, Quaternion.Euler(0, 0, 0));
       spawnedEnemy.GetComponent<EnemyController>().setPlayerReference(playerReference);
       spawnedEnemy.GetComponent<SkeletonMage>().updateLevel(modifier);
       increaseSpawnedEnemy();
    }

    private void increaseSpawnedEnemy()
    {
        spawnedEnemyCount++;
        if (numberOfSpawns < 7 && spawnedEnemyCount % 10 == 0)
        {
            numberOfSpawns++;
        }

        if (spawnCooldown > 5.0f && spawnedEnemyCount % 7 == 0)
        {
                spawnCooldown = spawnCooldown * 0.85f;
        }

        if (spawnedEnemyCount - lvlIncrease == 0)
        {
            if (lvlIncrease <= 640)
            {
                lvlIncrease += Mathf.RoundToInt(lvlIncrease / 2);
                lvlborder++;
            }
        }
    }
}
