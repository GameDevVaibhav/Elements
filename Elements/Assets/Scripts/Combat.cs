using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private Animator animator;
    public VFX vfx;

    

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
            // Add any logic you want to perform while jumping
        }
        else
        {
            // Check if combat is in progress before processing new combat inputs
            if (IsCurrentAnimation("Idle"))
            {
                if (Input.GetKeyDown(KeyCode.L) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S))
                {
                    // Trigger the punch animation.
                    StartCombatAction("Punch");
                }

                if (Input.GetKeyDown(KeyCode.K) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
                {
                    // Trigger the kick animation.
                    StartCombatAction("Kick");
                }

                if (Input.GetKeyDown(KeyCode.L) && Input.GetKey(KeyCode.S))
                {
                    // Trigger the power hit animation.
                    StartCombatAction("Power_Hit");
                }

                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.L))
                {
                    // Trigger the power punch animation.
                    StartCombatAction("Power_Punch");
                }

                if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.L))
                {
                    // Trigger the upper slash animation.
                    StartCombatAction("Upper_Slash");
                }

                if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.L))
                {
                    // Trigger the front slash animation.
                    StartCombatAction("Front_Slash");
                }

                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Q))
                {
                    // Trigger the cross slash animation.
                    StartCombatAction("Cross_Slash");
                }

                if (Input.GetKeyDown(KeyCode.X))
                {
                    // Trigger the smash animation.
                    StartCombatAction("Smash");
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Trigger the rock hit animation.
                    StartCombatAction("Rock_Hit");
                }

                if (Input.GetKeyDown(KeyCode.Z) && !Input.GetKey(KeyCode.LeftShift))
                {
                    // Trigger the top-bottom throw animation.
                    StartCombatAction("Top-Bottom_Throw");
                }

                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Z))
                {
                    // Trigger the ultimate throw animation.
                    StartCombatAction("Ultimate_Throw");
                }

                if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.K))
                {
                    // Trigger the tackle animation.
                    StartCombatAction("Tackle");
                }

                if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.K))
                {
                    // Trigger the spin kick animation.
                    StartCombatAction("Spin_Kick");
                }

                if (Input.GetKey(KeyCode.F))
                {
                    // Trigger the arrow throw animation.
                    StartCombatAction("Arrow_Throw");
                }

                if (Input.GetKey(KeyCode.LeftControl))
                {
                    // Trigger the clear animation.
                    StartCombatAction("Clear");
                }
            }


        }
    }

    // Method to start combat action and prevent multiple triggers
    private void StartCombatAction(string triggerName)
    {
       

        // Trigger the combat action animation
        animator.SetTrigger(triggerName);
        vfx.HandleVFX(triggerName);

        
    }

    private bool IsCurrentAnimation(string animationName)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(animationName);
    }

}
