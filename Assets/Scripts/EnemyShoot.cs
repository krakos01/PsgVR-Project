using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private float projectileSpeed;
    private float shootInterval = 3f;
    private Vector3 shootDirection;

    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            StartCoroutine(ShootAtPlayer());
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            shootDirection = (player.transform.position - transform.position - new Vector3(0, 0.5f, 0)).normalized;
        }
    }


    private IEnumerator ShootAtPlayer()
    {
        int enemiesDestroyed = GameManager.Instance.enemiesDestroyed;
        if (enemiesDestroyed < 120)
            shootInterval = 3 - enemiesDestroyed / 60;

        // Shoot every two seconds in player direction
        while (true)
        {
            LaunchProjectile(shootDirection);
            yield return new WaitForSeconds(shootInterval);
        }
    }


    void LaunchProjectile(Vector3 direction)
    {
        // Check if projetile prefab and spawn point are assigned
        if (projectilePrefab != null && projectileSpawnPoint != null)
        {
            // Don't look towards 0,0,0 (throws warning)
            if (direction != Vector3.zero)
            {
                // Instantiate projectile
                Instantiate(projectilePrefab, projectileSpawnPoint.position + new Vector3(0, 2, 0), Quaternion.LookRotation(direction));
            }
        }
    }

    void SetShootInterval(float interval)
    {
        shootInterval = interval; 
    }

}
