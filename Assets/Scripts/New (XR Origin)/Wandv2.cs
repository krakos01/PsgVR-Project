using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Wandv2 : MonoBehaviour
{
    private int ammoRecoveryTime = 1;  // How much seconds pass every 1 ammo recover; 1 sec may be to slow

    public InputActionProperty shoot;
    public int playerAmmo = 3;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RecoverProjectile", 0, ammoRecoveryTime);
    }

    // Update is called once per frame
    void Update()
    {
        
        LaunchProjectile();
    }


    /// <summary>
    ///  Create projectile at user's position and launch when pressend LMB
    /// </summary>
    void LaunchProjectile()
    {
        float triggerValue = shoot.action.ReadValue<float>();
        if (playerAmmo > 0 && triggerValue>0)
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.transform.rotation);
            playerAmmo--;
        }
    }


    /// <summary>
    /// Recover 1 projectile every second
    /// </summary>
    void RecoverProjectile()
    {
        if (playerAmmo < 3)
        {
            playerAmmo++;
        }
    }
}
