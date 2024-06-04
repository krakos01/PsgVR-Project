using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;

    private float spawnRangeX = 50;
    private float spawnRangeY = 50;
    private float spawnRangeZ = 50;
    private float startDelay = 2;
    private float spawnInterval = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemyAtRandomPosition", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Randomly generate spawn position
    void SpawnEnemyAtRandomPosition()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(1, spawnRangeY), Random.Range(-spawnRangeZ, spawnRangeZ));

        Instantiate(
            enemy,
            spawnPos,
            enemy.transform.rotation);
    }
}
