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
    public GameObject powerPunchVFX;
    
    public GameObject crossSlashVFX;
    public GameObject powerHitVFX;
    public GameObject lightningTarget;
    

    
    public Transform Target;
    public string light = "Lightning/";

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

                StartCoroutine(SpawnVFXWithDelay(light+ "/" + tackleVFX.name, 0.5f, Vector3.zero));
                break;
            case "Upper_Slash":
                StartCoroutine(SpawnVFXWithDelay(light+ "/" + upperSlashVFX.name, 0.3f, Vector3.zero));
                break;
            case "Smash":
                StartCoroutine(SpawnVFXWithDelay(light + "/" + smashVFX.name, 0.9f, Vector3.zero));
                break;
            case "Front_Slash":
                StartCoroutine(SpawnVFXWithDelay(light + "/" + frontSlashVFX.name, 0.5f, Vector3.zero));
                StartCoroutine(SpawnVFXWithDelay(light + "/" + frontSlash2VFX.name, 0.9f, Vector3.zero));
                break;
            case "Top-Bottom_Throw":
                StartCoroutine(SpawnVFXWithDelay(light + "/" + topBottomThrowVFX.name, 0.9f, new Vector3(0f, 0f, 0f)));
                break;
            case "Spin_Kick":
                StartCoroutine(SpawnVFXWithDelay(light + "/" + Spin_KickVFX.name, 0.9f, new Vector3(0f, 0f, 0f)));
                break;
            case "Power_Punch":
                StartCoroutine(SpawnVFXWithDelay(light + "/" + powerPunchVFX.name, 0.9f, new Vector3(-1f, 1f, 0f)));
                break;


            case "Ultimate_Throw":
                StartCoroutine(SpawnVFXWithDelay(light + "/" + ultimateThrowVFX.name, 2f, new Vector3(0f, -2.5f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(light + "/" + ultimateThrowVFX.name, 2f, new Vector3(-4f, 0f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(light + "/" + ultimateThrowVFX.name, 2f, new Vector3(-8f, 2f, 0f)));
                break;
            
            case "Cross_Slash":
                StartCoroutine(SpawnVFXWithDelay(light + "/" + crossSlashVFX.name, 1.2f, new Vector3(0f, 0f, 0f)));

                break;
            
            case "Power_Hit":
                StartCoroutine(SpawnVFXWithDelay(light + "/" + powerHitVFX.name, 1.1f, new Vector3(0f, 0f, 0f)));
                break;
            default:
                base.HandleVFX(combatAction);
                break;
        }
    }
}
