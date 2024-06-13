using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private int healthPoints = 2;
    private float projectileSpeed;
    private float shootInterval = 2f;
    private Vector3 shootDirection;

    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public GameObject player;

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
            shootDirection = (player.transform.position - transform.position).normalized;
        }
    }

    private IEnumerator ShootAtPlayer()
    {
        // Shoot every two seconds in player direction
        while (true)
        {
            LaunchProjectile(shootDirection);
            yield return new WaitForSeconds(shootInterval);
        }
    }



    void LaunchProjectile(Vector3 direction)
    {
        // Instantiate projectile
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);

        // Set projectile speed
        // projectile.GetComponent<Rigidbody>().velocity = direction * projectileSpeed;
    }

    public void TakeDamage(int dmg)
    {
        healthPoints -= dmg;

        if (healthPoints <= 0)
        {
            GameManager.Instance.EnemyDies(gameObject);
            GameManager.Instance.AddPoints(10);
        }
    }


    public void DestroyImmediately()
    {
        GameManager.Instance.EnemyDies(gameObject);
    }
}
