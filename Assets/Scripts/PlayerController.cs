using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float flyInput;
    private float horizontalInput;
    private float verticalInput;
    private float mouseInputX;
    private float mouseInputY;
    public int playerHP = 3;

    private CharacterController characterController;

    public float lowBound = 3;
    public float highBound = 100;
    public float playerSpeed = 100;

    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
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


    // Create projectile at user's position and launch when pressend LMB
    void LaunchProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.position, playerCamera.transform.rotation);
        }
    }

    
    // Inform GameManager that player hit obstacle
    public void TakeDamage(int dmg)
    {
        playerHP -= dmg;
        Debug.Log($"Player hp: {playerHP}");

        if (playerHP <= 0)
            GameManager.Instance.PlayerDied(gameObject);

    }
}
