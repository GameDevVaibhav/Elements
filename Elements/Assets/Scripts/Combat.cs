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
            
            if (Input.GetKeyDown(KeyCode.L) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.A))
            {
                // Trigger the punch animation.
                animator.SetTrigger("Punch");
            }

            
            if (Input.GetKeyDown(KeyCode.K) && !Input.GetKey(KeyCode.S))
            {
                // Trigger the kick animation.
                animator.SetTrigger("Kick");
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

            if (Input.GetKey(KeyCode.X))
            {
                
                animator.SetTrigger("Smash");
            }
            
            if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.K))
            {
                
                animator.SetTrigger("Tackle");
            }

        }
    }
}