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

    public AudioClip slashAudioClip;
    public AudioClip lightningStrikeClip;
    public AudioClip PowerHitAudioClip;
    public AudioClip ultimateThrowAudioClip;
    public AudioClip longPowerHitAudioClip;
    public AudioClip arrowAudioClip;
    public GameObject player;



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
                PlayAudio(slashAudioClip, 0.5f);
                break;
            case "Upper_Slash":
                StartCoroutine(SpawnVFXWithDelay(light+ "/" + upperSlashVFX.name, 0.3f, Vector3.zero));
                PlayAudio(slashAudioClip, 0.3f);
                break;
            case "Smash":
                StartCoroutine(SpawnVFXWithDelay(light + "/" + smashVFX.name, 0.9f, Vector3.zero));
                PlayAudio(slashAudioClip, 0.9f);
                break;
            case "Front_Slash":
                StartCoroutine(SpawnVFXWithDelay(light + "/" + frontSlashVFX.name, 0.5f, Vector3.zero));
                PlayAudio(slashAudioClip, 0.5f);
                StartCoroutine(SpawnVFXWithDelay(light + "/" + frontSlash2VFX.name, 0.9f, Vector3.zero));
                PlayAudio(slashAudioClip, 0.9f);
                break;
            case "Top-Bottom_Throw":
                StartCoroutine(SpawnVFXWithDelay(light + "/" + topBottomThrowVFX.name, 0.9f, new Vector3(0f, 0f, 0f)));
                PlayAudio(lightningStrikeClip, 0.5f);
                break;
            case "Spin_Kick":
                StartCoroutine(SpawnVFXWithDelay(light + "/" + Spin_KickVFX.name, 0.9f, new Vector3(0f, 0f, 0f)));
                PlayAudio(slashAudioClip, 0.9f);
                break;
            case "Power_Punch":
                StartCoroutine(SpawnVFXWithDelay(light + "/" + powerPunchVFX.name, 0.9f, new Vector3(-1f, 1f, 0f)));
                PlayAudio(PowerHitAudioClip, 0.9f);
                break;


            case "Ultimate_Throw":
                StartCoroutine(SpawnVFXWithDelay(light + "/" + ultimateThrowVFX.name, 2f, new Vector3(0f, -2.5f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(light + "/" + ultimateThrowVFX.name, 2f, new Vector3(-4f, 0f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(light + "/" + ultimateThrowVFX.name, 2f, new Vector3(-8f, 2f, 0f)));
                PlayAudio(lightningStrikeClip, 1.5f);
                break;
            
            case "Cross_Slash":
                StartCoroutine(SpawnVFXWithDelay(light + "/" + crossSlashVFX.name, 1.2f, new Vector3(0f, 0f, 0f)));
                PlayAudio(lightningStrikeClip, 1f);
                break;
            
            case "Power_Hit":
                StartCoroutine(SpawnVFXWithDelay(light + "/" + powerHitVFX.name, 1.1f, new Vector3(0f, 0f, 0f)));
                PlayAudio(PowerHitAudioClip, 1.1f);
                break;
            default:
                base.HandleVFX(combatAction);
                break;
        }
    }
}
