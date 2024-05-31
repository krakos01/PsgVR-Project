using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float lowBound = 1;
    private float highBound = 100;

    public float playerSpeed = 100;
    public float flyInput;
    public float horizontalInput;
    public float verticalInput;
    public float mouseInputX;
    public float mouseInputY;

    public GameObject projectilePrefab;
    public Vector3 projectileOffset = Vector3.forward;

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

        Debug.Log(mouseInputX.ToString());

        // Fly down/up only if in bounds
        if (!((transform.position.y <= lowBound && flyInput < 0) || (transform.position.y >= highBound && flyInput > 0)))
            transform.Translate(Vector3.up * Time.deltaTime * playerSpeed * flyInput);

        transform.Translate(Vector3.right * Time.deltaTime * playerSpeed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed * verticalInput);

        //transform.Rotate(Vector3.down * Time.deltaTime * mouseInputX * 100);  // Vector3.up > 0 -> turn right
        //transform.Rotate(Vector3.left * Time.deltaTime * mouseInputY * 100);  // Vector3.left > 0 -> turn down

        LaunchProjectile();
    }

    

    // Create projectile at user's position and launch when pressend LMB
    void LaunchProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectilePrefab, transform.position + projectileOffset*2, projectilePrefab.transform.rotation);
        }
    }
}
