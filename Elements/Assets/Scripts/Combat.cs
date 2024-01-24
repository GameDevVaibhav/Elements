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
            
            if (Input.GetKeyDown(KeyCode.L) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S))
            {
                // Trigger the punch animation.
                animator.SetTrigger("Punch");
            }

            
            if (Input.GetKeyDown(KeyCode.K) && !Input.GetKey(KeyCode.S)&&!Input.GetKey(KeyCode.W))
            {
                // Trigger the kick animation.
                animator.SetTrigger("Kick");
            }
            if (Input.GetKeyDown(KeyCode.L) && Input.GetKey(KeyCode.S))
            {
                // Trigger the kick animation.
                animator.SetTrigger("Power_Hit");
            }


            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.L))
            {
                
                animator.SetTrigger("Power_Punch");
            }

            
            if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.L))
            {
                
                animator.SetTrigger("Upper_Slash");
            }

            if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.L))
            {
                
                animator.SetTrigger("Front_Slash");
            }

            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Q))
            {
                
                animator.SetTrigger("Cross_Slash");
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                
                animator.SetTrigger("Smash");
            }

            if (Input.GetKeyDown(KeyCode.E))
            {

                animator.SetTrigger("Rock_Hit");
            }

            if (Input.GetKeyDown(KeyCode.Z)&& !Input.GetKey(KeyCode.LeftShift))
            {

                animator.SetTrigger("Top-Bottom_Throw");
            }

            if (Input.GetKey(KeyCode.LeftShift)&& Input.GetKeyDown(KeyCode.Z))
            {

                animator.SetTrigger("Ultimate_Throw");
            }

            if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.K))
            {
                
                animator.SetTrigger("Tackle");
            }
            if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.K))
            {

                animator.SetTrigger("Spin_Kick");
            }
        }
    }
}
