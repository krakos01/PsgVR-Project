using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float flyInput;
    private float horizontalInput;
    private float verticalInput;
    private float mouseInputX;
    private float mouseInputY;
    private int playerHP = 3;
    private int playerAmmoRecoveryTime = 1;  // How much seconds pass every 1 ammo recover; 1 sec may be to slow

    private CharacterController characterController;

    public float lowBound = 3;
    public float highBound = 100;
    public float playerSpeed = 100;
    public int playerAmmo = 3;

    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public Camera playerCamera;

    /// <summary>
    // Start is called before the first frame update
    /// </summary>
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        InvokeRepeating("RecoverProjectile", 0, playerAmmoRecoveryTime);
    }

    /// Update is called once per frame
    void Update()
    {
        // Get info from keys
        flyInput = Input.GetAxis("Fly");  // left shift: UP, left ctrl: DOWN
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Fly down/up only if in bounds
        if (!((transform.position.y <= lowBound && flyInput < 0) || (transform.position.y >= highBound && flyInput > 0)))
        {
            characterController.Move(transform.TransformDirection(Vector3.up) * Time.deltaTime * playerSpeed * flyInput);
        }
        

        characterController.Move(transform.TransformDirection(Vector3.right) * Time.deltaTime * playerSpeed * horizontalInput);
        characterController.Move(transform.TransformDirection(Vector3.forward) * Time.deltaTime * playerSpeed * verticalInput);


        LaunchProjectile();
    }


    /// <summary>
    ///  Create projectile at user's position and launch when pressend LMB
    /// </summary>
    void LaunchProjectile()
    {
        if (playerAmmo>0 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.position, playerCamera.transform.rotation);
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


    /// Inform GameManager that player hit obstacle
    public void TakeDamage(int dmg)
    {
        playerHP -= dmg;
        Debug.Log($"Player hp: {playerHP}");

        if (playerHP <= 0)
            GameManager.Instance.PlayerDied(gameObject);

    }
}