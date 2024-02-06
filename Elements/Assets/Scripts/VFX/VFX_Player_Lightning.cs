using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_Player_Lightning : BaseVFX
{
    public GameObject tackleVFX;
    public GameObject upperSlashVFX;
    public GameObject smashVFX;
    public GameObject frontSlashVFX;
    public GameObject frontSlash2VFX;
    public GameObject topBottomThrowVFX;
    public GameObject Spin_KickVFX;
    
    public GameObject ultimateThrowVFX;
    
    
    public GameObject crossSlashVFX;
    public GameObject powerHitVFX;
    public GameObject lightningTarget;
    

    
    public Transform Target;


    // Override the Start method if needed for specific initialization
    protected override void Start()
    {
        base.Start();
        // Additional initialization for Player_Fire type
    }

    public override void HandleVFX(string combatAction)
    {
        switch (combatAction)
        {
            case "Tackle":

                StartCoroutine(SpawnVFXWithDelay(tackleVFX, 0.5f, Vector3.zero));
                break;
            case "Upper_Slash":
                StartCoroutine(SpawnVFXWithDelay(upperSlashVFX, 0.3f, Vector3.zero));
                break;
            case "Smash":
                StartCoroutine(SpawnVFXWithDelay(smashVFX, 0.9f, Vector3.zero));
                break;
            case "Front_Slash":
                StartCoroutine(SpawnVFXWithDelay(frontSlashVFX, 0.5f, Vector3.zero));
                StartCoroutine(SpawnVFXWithDelay(frontSlash2VFX, 0.9f, Vector3.zero));
                break;
            case "Top-Bottom_Throw":
                StartCoroutine(SpawnVFXWithDelay(topBottomThrowVFX, 0.9f, new Vector3(0f, 0f, 0f)));
                break;
            case "Spin_Kick":
                StartCoroutine(SpawnVFXWithDelay(Spin_KickVFX, 0.9f, new Vector3(0f, 0f, 0f)));
                break;
            
                
                
            case "Ultimate_Throw":
                StartCoroutine(SpawnVFXWithDelay(ultimateThrowVFX, 2f, new Vector3(0f, -2.5f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(ultimateThrowVFX, 2f, new Vector3(-4f, 0f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(ultimateThrowVFX, 2f, new Vector3(-8f, 2f, 0f)));
                break;
            
            case "Cross_Slash":
                StartCoroutine(SpawnVFXWithDelay(crossSlashVFX, 1.2f, new Vector3(0f, 0f, 0f)));

                break;
            
            case "Power_Hit":
                StartCoroutine(SpawnVFXWithDelay(powerHitVFX, 1.1f, new Vector3(0f, 0f, 0f)));
                break;
            default:
                base.HandleVFX(combatAction);
                break;
        }
    }
}
