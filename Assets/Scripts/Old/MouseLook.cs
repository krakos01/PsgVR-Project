using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Hide cursor and block in the middle
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate on the Y (left-right) axis
        playerBody.Rotate(Vector3.up * mouseX);

        // Rotate on the X (up-down) axis
        xRotation -= mouseY;
        // xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit rotation angle to avoid full rotation

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
