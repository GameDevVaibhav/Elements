using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_Player_Fire : BaseVFX
{
    public GameObject tackleVFX;
    public GameObject upperSlashVFX;
    public GameObject smashVFX;
    public GameObject frontSlashVFX;
    public GameObject frontSlash2VFX;
    public GameObject topBottomThrowVFX;
    public GameObject Spin_KickVFX;
    public GameObject Rock_HitVFX;
    public GameObject ultimateThrowVFX;
    public GameObject longPowerHitVFX;
    public GameObject longPowerHitSlashVFX;
    public GameObject arrowThrowVFX;
    public GameObject arrowVFX;

    public AudioClip slashAudioClip;
    public AudioClip topBottomThrowAudioClip;
    public AudioClip Rock_HitAudioClip;
    public AudioClip ultimateThrowAudioClip;
    public AudioClip longPowerHitAudioClip;
    public AudioClip arrowAudioClip;
    public GameObject player;

    public string fire = "Fire";

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
                
                StartCoroutine(SpawnVFXWithDelay(fire+ "/"+tackleVFX.name, 0.5f, Vector3.zero));
                PlayAudio(slashAudioClip,0.5f);
                break;
            case "Upper_Slash":
                StartCoroutine(SpawnVFXWithDelay(fire+ "/" + upperSlashVFX.name, 0.3f, Vector3.zero));
                PlayAudio(slashAudioClip,0.3f);
                break;
            case "Smash":
                StartCoroutine(SpawnVFXWithDelay(fire+ "/" + smashVFX.name, 0.9f, Vector3.zero));
                PlayAudio(slashAudioClip, 0.9f);
                break;
            case "Front_Slash":
                StartCoroutine(SpawnVFXWithDelay(fire+ "/" + frontSlashVFX.name, 0.5f, Vector3.zero));
                PlayAudio(slashAudioClip, 0.5f);
                StartCoroutine(SpawnVFXWithDelay(fire+ "/" + frontSlash2VFX.name, 0.9f, Vector3.zero));
                PlayAudio(slashAudioClip, 0.9f);
                break;
            case "Top-Bottom_Throw":
                StartCoroutine(SpawnVFXWithDelay(fire + "/" + topBottomThrowVFX.name, 0.3f, new Vector3(0f, 5f, 0f)));
                break;
            case "Spin_Kick":
                StartCoroutine(SpawnVFXWithDelay(fire + "/" + Spin_KickVFX.name, 0.9f, new Vector3(0f, 0f, 0f)));
                PlayAudio(slashAudioClip, 0.9f);
                break;
            case "Rock_Hit":
                StartCoroutine(SpawnVFXWithDelay(fire + "/" + Rock_HitVFX.name, 0.7f, new Vector3(-3f, -2.5f, 0f)));
                break;
            case "Ultimate_Throw":
                StartCoroutine(SpawnVFXWithDelay(fire + "/" + ultimateThrowVFX.name, 0.7f, new Vector3(-3f, -2.5f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(fire + "/" + ultimateThrowVFX.name, 0.5f, new Vector3(-2f, -2.5f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(fire + "/" + ultimateThrowVFX.name, 0.4f, new Vector3(-1f, -2.5f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(fire + "/" + ultimateThrowVFX.name, 0.7f, new Vector3(0f, -2.5f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(fire + "/" + ultimateThrowVFX.name, 0.5f, new Vector3(1f, -2.5f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(fire + "/" + ultimateThrowVFX.name, 0.4f, new Vector3(2f, -2.5f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(fire + "/" + ultimateThrowVFX.name, 0.7f, new Vector3(3f, -2.5f, 0f)));
                break;
            case "Long_Power_Hit":
                StartCoroutine(SpawnVFXWithDelay(fire+ "/" + longPowerHitVFX.name, 0.3f, new Vector3(0f, 0f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(fire+ "/" + longPowerHitSlashVFX.name, 1.3f, new Vector3(0f, 0f, 0f)));
                PlayAudio(slashAudioClip, 1.3f);
                break;
            case "Arrow_Throw":
                StartCoroutine(SpawnVFXWithDelay(fire + "/" + arrowThrowVFX.name, 0.3f, new Vector3(0f, 0f, 0f)));
                PlayAudio(slashAudioClip, 0.3f);
                StartCoroutine(SpawnVFXWithDelay(fire + "/" + arrowVFX.name, 0.5f, new Vector3(-3.5f, 0.4f, 0f)));
                PlayAudio(arrowAudioClip, 0.5f);
                StartCoroutine(SpawnVFXWithDelay(fire + "/" + arrowVFX.name, 0.8f, new Vector3(-3.5f, 0.4f, 0f)));
                PlayAudio(arrowAudioClip, 0.8f);
                StartCoroutine(SpawnVFXWithDelay(fire + "/" + arrowVFX.name, 1.5f, new Vector3(-3.5f, 0.4f, 0f)));
                PlayAudio(arrowAudioClip, 1.5f);
                StartCoroutine(SpawnVFXWithDelay(fire + "/" + arrowVFX.name, 1.6f, new Vector3(-3.5f, 0.4f, 0f)));
                PlayAudio(arrowAudioClip, 1.6f);
                break;
            
            default:
                base.HandleVFX(combatAction);
                break;

        }
    }

   

}
