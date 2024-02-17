using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private Animator animator;
    public BaseVFX vfx;

    CombatMovement combatMovement;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component.
        animator = GetComponent<Animator>();
       // vfx=GetComponent<BaseVFX>();
    }

    // Update is called once per frame
    void Update()
    {

        Controls();
       
    }

    // Method to start combat action and prevent multiple triggers
    private void StartCombatAction(string triggerName)
    {
       

        // Trigger the combat action animation
        animator.SetTrigger(triggerName);
        vfx.HandleVFX(triggerName);

        
    }
    private void Controls()
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
                    if (gameObject.CompareTag("Player_Lightning") || gameObject.CompareTag("Player_Earth"))
                    {
                        StartCombatAction("Power_Hit");
                    }
                        
                }

                if (Input.GetKeyDown(KeyCode.Q) && !Input.GetKey(KeyCode.LeftShift))
                {
                    if(!gameObject.CompareTag("Player_Lightning") && !gameObject.CompareTag("Player_Earth"))
                    {
                        StartCombatAction("Long_Power_Hit");
                    }
                    

                }

                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.L))
                {
                    if (gameObject.CompareTag("Player_Lightning"))
                    {
                        StartCombatAction("Power_Punch");
                    }
                    else { return; }
                    
                }

                if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.L))
                {
                    // Trigger the upper slash animation.
                    StartCombatAction("Upper_Slash");
                }

                if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.L))
                {
                    
                    StartCombatAction("Front_Slash");
                }

                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Q))
                {
                    if (gameObject.CompareTag("Player_Lightning"))
                    {
                        StartCombatAction("Cross_Slash");
                    }
                        
                }

                if (Input.GetKeyDown(KeyCode.X))
                {
                    // Trigger the smash animation.
                    StartCombatAction("Smash");
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (gameObject.CompareTag("Player_Lightning"))
                    {
                        return;
                    }
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

                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (!gameObject.CompareTag("Player_Lightning") && !gameObject.CompareTag("Player_Earth"))
                    {
                        StartCombatAction("Arrow_Throw");
                    }
                    else
                    {
                        
                    }
                }

                if (Input.GetKey(KeyCode.LeftControl))
                {
                    // Trigger the clear animation.
                    StartCombatAction("Clear");
                }
            }


        }
    }

    private bool IsCurrentAnimation(string animationName)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(animationName);
    }

}
