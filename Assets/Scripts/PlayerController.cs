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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get info from keys
        flyInput = Input.GetAxis("Fly");
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Fly down/up only if in bounds
        if (!((transform.position.y <= lowBound && flyInput < 0) || (transform.position.y >= highBound && flyInput > 0)))
            transform.Translate(Vector3.up * Time.deltaTime * playerSpeed * flyInput);


        transform.Translate(Vector3.right * Time.deltaTime * playerSpeed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed * verticalInput);
    }
}
