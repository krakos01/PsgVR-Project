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

    public float lowBound = 1;
    public float highBound = 100;
    public float playerSpeed = 100;

    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
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
        if (!((transform.position.y <= lowBound && flyInput < 0) || (transform.position.y >= highBound && flyInput > 0)))
            transform.Translate(Vector3.up * Time.deltaTime * playerSpeed * flyInput);

        transform.Translate(Vector3.right * Time.deltaTime * playerSpeed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed * verticalInput);


        LaunchProjectile();
    }

    

    // Create projectile at user's position and launch when pressend LMB
    void LaunchProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        }
    }
}
