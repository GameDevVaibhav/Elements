using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

//This script takes the Input key combination to start combat action. It calls the HandleVfx method and passes triggername.
public class Combat : MonoBehaviour
{
    private Animator animator;
    public BaseVFX vfx;

    CombatMovement combatMovement;
    PhotonView PV;
    string pvOwner;

    Play_UI play_ui;
    

    string playerType;

    bool fire, water, lightning, earth=false;


    private bool gameOver = false;
    GameObject gameOverUi;

    
    void Start()
    {
        

        PV = GetComponent<PhotonView>();

        pvOwner= PV.Owner.ToString();
        
        animator = GetComponent<Animator>();

        playerType = PlayerPrefs.GetString("SelectedPlayerType", "Player_Fire");

        fire = playerType == "Player_Fire" ? true : false;
        water = playerType == "Player_Water" ? true : false;
        lightning= playerType == "Player_Lightning" ? true : false;
        earth = playerType == "Player_Earth" ? true : false;

    }

   
    void Update()
    {
        gameOverUi = GameObject.FindGameObjectWithTag("GameOverUi");
        if (gameOverUi != null)
        {
            Debug.Log("Found gameover");
            return;
        }
        if (gameOver)
        {

            return;
        }


        if (!PV.IsMine)
        {
            return;
        }
        Controls();
       
    }

    
    private void StartCombatAction(string triggerName)
    {

        if (triggerName == "Punch" || triggerName == "Kick")
        {
            animator.SetTrigger(triggerName);
            
        }

        else
        {
            animator.SetTrigger(triggerName);
            vfx.HandleVFX(triggerName);
        }

        
    }

   
   


    private void Controls()
    {
        if (animator.GetBool("isJumping"))
        {
            
        }
        else
        {
           
            if (IsCurrentAnimation("Idle") || IsCurrentAnimation("Walk") || IsCurrentAnimation("ReverseWalk"))
            {
                

                if (Input.GetKeyDown(KeyCode.L) && Input.GetKey(KeyCode.S))
                {
                    if (lightning || earth)
                    {
                        StartCombatAction("Power_Hit");
                    }
                        
                }

                if (Input.GetKeyDown(KeyCode.Q) && !Input.GetKey(KeyCode.LeftShift))
                {
                    if(!lightning )
                    {
                        StartCombatAction("Long_Power_Hit");
                    }
                    

                }

                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.L))
                {
                    if (lightning)
                    {
                        StartCombatAction("Power_Punch");
                    }
                    else { return; }
                    
                }

                if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.L))
                {
                    
                    StartCombatAction("Upper_Slash");
                }

                if (Input.GetKeyDown(KeyCode.F))
                {
                    
                    StartCombatAction("Front_Slash");
                }

                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Q))
                {
                    if (lightning)
                    {
                        StartCombatAction("Cross_Slash");
                    }
                        
                }

                if (Input.GetKeyDown(KeyCode.X))
                {
                    
                    StartCombatAction("Smash");
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (lightning)
                    {
                        return;
                    }
                    StartCombatAction("Rock_Hit");
                }

                if (Input.GetKeyDown(KeyCode.Z) && !Input.GetKey(KeyCode.LeftShift))
                {
                    
                    StartCombatAction("Top-Bottom_Throw");
                }

                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Z))
                {
                    StartCombatAction("Ultimate_Throw");

                   
                    
                }

                if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.K))
                {
                   
                    StartCombatAction("Tackle");
                }

                if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.K))
                {
                   
                    StartCombatAction("Spin_Kick");
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (!lightning && !earth)
                    {
                        StartCombatAction("Arrow_Throw");
                    }
                    else
                    {
                        
                    }
                }

                //if (Input.GetKey(KeyCode.LeftControl))
                //{
                    
                //    StartCombatAction("Clear");
                //}


            }


        }
    }

    private bool IsCurrentAnimation(string animationName)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(animationName);
    }

   
}
