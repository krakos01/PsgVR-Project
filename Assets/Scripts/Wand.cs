using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class Wand : MonoBehaviour
{
    private int ammoRecoveryTime = 1;  // How much seconds pass every 1 ammo recover; 1 sec may be to slow
    
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
        if (playerAmmo > 0 && (Input.GetKeyDown(KeyCode.Mouse0)))
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
