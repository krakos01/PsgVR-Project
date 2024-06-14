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

    public float rotationSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            StartCoroutine(SetDirectionAtPlayer());
            StartCoroutine(ShootAtPlayer());
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            shootDirection = (player.transform.position - transform.position - new Vector3(0, 0.3f, 0)).normalized;
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

    private IEnumerator SetDirectionAtPlayer()
    {
        while (true)
        {
            LookAtPlayer(shootDirection);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void LookAtPlayer(Vector3 direction)
    {
        if (direction != Vector3.zero)
            {
                Vector3 Lookdirection = player.transform.position - transform.position;

                Quaternion targetRotation = Quaternion.LookRotation(Lookdirection);


                targetRotation = Quaternion.Euler(Vector3.up * -90);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime* rotationSpeed);
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
                Instantiate(projectilePrefab, projectileSpawnPoint.position + new Vector3(2.851f, 0.849f, -0.749f), Quaternion.LookRotation(direction));
            }
        }
    }

    void SetShootInterval(float interval)
    {
        shootInterval = interval; 
    }

}
