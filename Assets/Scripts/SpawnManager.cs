using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;

    private float spawnRangeX = 50;
    private float spawnRangeY = 50;
    private float spawnRangeZ = 50;
    private float startDelay = 5;
    private List<Vector3> enemiesPositions = new List<Vector3>();

    public float spawnInterval = 5;
    public float minEnemyDistance = 5;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Randomly generate spawn position
    private void SpawnEnemy()
    {
        Vector3 spawnPos = GetPosition();
        Debug.Log(spawnPos);

        if (spawnPos != Vector3.zero) // Check if a valid position was found
        {
            Instantiate(enemy, spawnPos, enemy.transform.rotation);
            enemiesPositions.Add(spawnPos); // Update list of existing enemy positions
        }
        else
        {
            Debug.LogWarning("Failed to find a suitable spawn position after multiple attempts.");
        }
    }


    /// <summary>
    ///  Generate position for enemy.
    /// </summary>
    /// <param name="checkIsValid">Check if generated position is valid. Only used when too much enemies are on map.</param>
    /// <returns>Position in some distance from another enemies if param set to true or random position if false</returns>
    private Vector3 GetPosition(bool checkIsValid = true)
    {
        // Return random position without checking if is valid.
        if (!checkIsValid)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(-spawnRangeX, spawnRangeX),
                Random.Range(1, spawnRangeY),
                Random.Range(-spawnRangeZ, spawnRangeZ)
            );

            return randomPos;
        }

        // Try to find valid position
        int maxAttempts = 100;  // Maximum attempts to find a valid position
        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(-spawnRangeX, spawnRangeX),
                Random.Range(1, spawnRangeY),
                Random.Range(-spawnRangeZ, spawnRangeZ)
            );

            if (checkIsValid & IsPositionValid(randomPos))
            {
                return randomPos;
            }
        }
        
        // Return zero vector if no valid position is found
        return Vector3.zero;
    }

    /// <summary>
    /// True if distance between enemies is higher than minimum allowed.
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    private bool IsPositionValid(Vector3 position)
    {
        foreach(Vector3 pos in enemiesPositions)
        {
            float distance = Vector3.Distance(position, pos);
            if (distance < minEnemyDistance)
            {
                return false;
            }
        }

        return true;
    }
}
