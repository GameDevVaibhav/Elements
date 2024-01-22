using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component.
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (animator.GetBool("isJumping"))
        {

        }
        else
        {
            // Check for input to trigger the punch animation.
            if (Input.GetKeyDown(KeyCode.L) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.A))
            {
                // Trigger the punch animation.
                animator.SetTrigger("Punch");
            }

            // Check for input to trigger the kick animation.
            if (Input.GetKeyDown(KeyCode.K) && !Input.GetKey(KeyCode.S))
            {
                // Trigger the kick animation.
                animator.SetTrigger("Kick");
            }

            // Check for input to trigger the power_punch animation.
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.L))
            {
                // Trigger the power_punch animation.
                animator.SetTrigger("Power_Punch");
            }

            // Check for input to trigger the upper_slash animation.
            if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.L))
            {
                // Trigger the upper_slash animation.
                animator.SetTrigger("Upper_Slash");
            }

            if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.L))
            {
                // Trigger the upper_slash animation.
                animator.SetTrigger("Front_Slash");
            }

            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Q))
            {
                // Trigger the upper_slash animation.
                animator.SetTrigger("Cross_Slash");
            }
            // Check for input to trigger the tackle animation.
            if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.K))
            {
                // Trigger the tackle animation.
                animator.SetTrigger("Tackle");
            }

        }
    }
}
