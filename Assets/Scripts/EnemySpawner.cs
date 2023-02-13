using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    float maxRateOfSpawn = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", maxRateOfSpawn);

        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject anEnemy = (GameObject)Instantiate(enemy);

        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        NextSpawn(); 
    }

    void NextSpawn()
    {
        float spawnInSeconds;

        if (maxRateOfSpawn > 1f)
        {
            spawnInSeconds = Random.Range(1f, maxRateOfSpawn);
        }
        else
        {
            spawnInSeconds = 1f;
        }

        Invoke("SpawnEnemy", spawnInSeconds);
    }
       

        void IncreaseSpawnRate()
        {
            if(maxRateOfSpawn > 1f)
            {
                maxRateOfSpawn--;
            }
            if(maxRateOfSpawn == 1f)
            {
                CancelInvoke("IncreaseSpawnRate");
            }
        }



    
}
