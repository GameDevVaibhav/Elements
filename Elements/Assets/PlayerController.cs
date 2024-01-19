using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f; // Adjust the jump force as needed.
    private bool isGrounded;

    void Update()
    {
        // Get input for horizontal movement.
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the movement vector.
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);

        // Move the player using Rigidbody2D.
        transform.position += movement * moveSpeed * Time.deltaTime;

        // Check for jumping input and if the player is grounded.
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Apply an upward force to simulate jumping.
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, jumpForce);

        // Set grounded state to false to prevent double jumps.
        isGrounded = false;
    }

    // Check if the player is grounded.
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
