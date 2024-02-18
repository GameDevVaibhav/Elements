using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Adjust the speed of rotation
    public float movementSpeed = 1.0f; // Adjust the speed of movement

    void Update()
    {
        // Rotate the object around the Z-axis
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        // Move the object to the left
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime, Space.World);

        // If you want to rotate from 0 to 200 degrees, you can use the following condition
        if (transform.eulerAngles.z >= 130f)
        {
            // Change the rotation speed to 200
            rotationSpeed = 250.0f;
        }
        if (transform.eulerAngles.z >= 230f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Opponent"))
        {
            Debug.Log("Hit registered");
            Destroy(gameObject);
        }
    }
}
