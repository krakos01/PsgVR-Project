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
        mouseInputX = Input.GetAxis("Mouse X");
        mouseInputY = Input.GetAxis("Mouse Y");

        //Debug.Log(mouseInputX.ToString());

        // Fly down/up only if in bounds
        if ((transform.position.y <= lowBound && flyInput < 0) || (transform.position.y >= highBound && flyInput > 0))
            flyInput = 0;

        Vector3 move = new Vector3(horizontalInput, flyInput, verticalInput);
        characterController.Move(move* Time.deltaTime * playerSpeed);


            
           // transform.Translate(Vector3.up * Time.deltaTime * playerSpeed * flyInput);


        //transform.Translate(Vector3.right * Time.deltaTime * playerSpeed * horizontalInput);
        //transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed * verticalInput);


        LaunchProjectile();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Take 1 HP from player.
            playerHP--;
            if (playerHP == 0)
            {
                Destroy(gameObject);
            }
        }
    }


    // Create projectile at user's position and launch when pressend LMB
    void LaunchProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.position, playerCamera.transform.rotation);
        }
    }
}
