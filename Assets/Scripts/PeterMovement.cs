using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeterMovement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float movementSpeed = 3f;
    [SerializeField] float jumpForce = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Lock cursor to center of screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, 5f, rb.velocity.z);
        }

        // Mouse when users moves mouse, the camera will move
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(0f, mouseX, 0f);
        Camera.main.transform.Rotate(-mouseY, 0f, 0f);

        // Sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = 6f;
        }
        else
        {
            movementSpeed = 3f;
        }
    }
}
