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
        // Check for input to trigger the punch animation.
        if (Input.GetKeyDown(KeyCode.L))
        {
            // Trigger the punch animation.
            animator.SetTrigger("Punch");
        }

        // Check for input to trigger the kick animation.
        if (Input.GetKeyDown(KeyCode.K))
        {
            // Trigger the kick animation.
            animator.SetTrigger("Kick");
        }
    }
}

