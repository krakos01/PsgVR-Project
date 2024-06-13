using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy_easy;
    [SerializeField]
    private GameObject enemy_difficult;

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



    // Select enemy based on probability
    private bool ShouldSpawnEasyEnemy()
    {
        int random_value = Random.Range(0, 100);

        if (random_value < 70) return true;
        else return false;
    }


    // Randomly generate spawn position
    private void SpawnEnemy()
    {
        Vector3 spawnPos = GetPosition();
        float spawnRot = GetRotation();

        bool easyEnemy = ShouldSpawnEasyEnemy();

        if (spawnPos != Vector3.zero)  // Check if a valid position was found
        {
            if (easyEnemy)
                Instantiate(enemy_easy, spawnPos, Quaternion.Euler(0, spawnRot, 0));
            else
                Instantiate(enemy_difficult, spawnPos, Quaternion.Euler(0, spawnRot, 0));

            enemiesPositions.Add(spawnPos);  // Update list of existing enemy positions
        }
        else
        {
            Debug.LogWarning("Failed to find a suitable spawn position after multiple attempts.");
        }
    }



    //  Generate position for enemy.
    private Vector3 GetPosition()
    {
        // Try to find valid position
        int maxAttempts = 100;
        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(-spawnRangeX, spawnRangeX),
                Random.Range(1, spawnRangeY),
                Random.Range(-spawnRangeZ, spawnRangeZ)
            );

            if (IsPositionValid(randomPos))
            {
                return randomPos;
            }
        }
        
        // Return zero vector if no valid position is found
        return Vector3.zero;
    }


    private float GetRotation()
    {
        // Set random Rotation
        float randomRot = 0;
        randomRot = Random.Range(0f, 360f);
        return randomRot;
    }


    // True if distance between enemies is higher than minimum allowed.
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
