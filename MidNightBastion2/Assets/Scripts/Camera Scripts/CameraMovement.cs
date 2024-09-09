using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // Speed of camera movement
    public float sensitivity = 2f; // Sensitivity for mouse look (optional)
    public float maxYAngle = 80f; // Max vertical angle for mouse look (optional)
    private float yaw = 0f; // Current yaw angle (for mouse look)
    private float pitch = 0f; // Current pitch angle (for mouse look)

    void Update()
    {
        // Keyboard movement
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float vertical = Input.GetAxis("Vertical"); // W/S or Up/Down arrow keys

        Vector3 moveDirection = (transform.forward * vertical + transform.right * horizontal).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Mouse look (optional)
        if (Input.GetMouseButton(1)) // Right mouse button
        {
            yaw += sensitivity * Input.GetAxis("Mouse X");
            pitch -= sensitivity * Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, -maxYAngle, maxYAngle);

            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }
    }
}
