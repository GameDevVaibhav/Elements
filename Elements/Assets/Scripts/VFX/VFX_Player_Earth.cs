using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class VFX_Player_Earth : BaseVFX
{
    public GameObject tackleVFX;
    public GameObject upperSlashVFX;
    public GameObject smashVFX;
    public GameObject frontSlashVFX;
    public GameObject frontSlash2VFX;
    public GameObject topBottomThrowVFX;
    public GameObject Spin_KickVFX;
    public GameObject Rock_HitVFX;
    public GameObject smallRockVFX;
    public GameObject ultimateThrowVFX;
    public GameObject longPowerHitVFX;
    public GameObject longPowerHitSlashVFX;
    public GameObject powerHitVFX;

    private Transform targett;
    public string earth = "Earth/";

    public AudioClip slashAudioClip;
    public AudioClip topBottomThrowAudioClip;
    public AudioClip Rock_HitAudioClip;
    public AudioClip ultimateThrowAudioClip;
    public AudioClip longPowerHitAudioClip;
    public AudioClip smashAudioClip;
    public GameObject player;




    // Override the Start method if needed for specific initialization
    protected override void Start()
    {
        base.Start();

        GameObject targetObject=GameObject.FindGameObjectWithTag("Opponent");

        //target = targetObject.transform;
        //Debug.Log("opponent" + target.position);

        

    }

   

    public override void HandleVFX(string combatAction)
    {
        switch (combatAction)
        {
            case "Tackle":

                StartCoroutine(SpawnVFXWithDelay(earth+ "/" + tackleVFX.name, 0.5f, Vector3.zero));
                PlayAudio(slashAudioClip, 0.5f);
                break;
            case "Upper_Slash":
                StartCoroutine(SpawnVFXWithDelay(earth+ "/" + upperSlashVFX.name, 0.3f, Vector3.zero));
                PlayAudio(slashAudioClip, 0.3f);
                break;
            case "Smash":
                StartCoroutine(SpawnVFXWithDelay(earth+ "/" + smallRockVFX.name, 1.1f, new Vector3(-3f, 0f, 0f)));
                PlayAudio(smashAudioClip, 1.1f);
                break;
            case "Front_Slash":
                
               // StartCoroutine(SpawnVFXWithDelay(earth + "/" + smallRockVFX.name, 0.5f, new Vector3(3.5f, 0f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(earth + "/" + frontSlashVFX.name, 0.5f, new Vector3(3.5f, -2.5f, 0f)));
                //StartCoroutine(SpawnVFXWithDelay(earth + "/" + smallRockVFX.name, 0.9f, new Vector3(3.5f, 0f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(earth + "/" + frontSlash2VFX.name, 0.9f, new Vector3(3.5f, -2.5f, 0f)));
                break;
            case "Top-Bottom_Throw":
                StartCoroutine(SpawnVFXWithDelay(earth + "/" + topBottomThrowVFX.name, 0.3f, new Vector3(0f, 5f, 0f)));
                
                break;
            case "Spin_Kick":
                StartCoroutine(SpawnVFXWithDelay(earth + "/" + Spin_KickVFX.name, 0.9f, new Vector3(0f, 0f, 0f)));
                PlayAudio(slashAudioClip, 0.9f);
                break;
            case "Rock_Hit":
                StartCoroutine(SpawnVFXWithDelay(earth + "/" + Rock_HitVFX.name, 0.7f, new Vector3(-3f, -2.5f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(earth + "/" + smallRockVFX.name, 0.7f, new Vector3(-3f, 0f, 0f)));
                break;
            case "Ultimate_Throw":
                StartCoroutine(SpawnVFXWithDelay(earth + "/" + smallRockVFX.name, 0.7f, new Vector3(-3f, 0f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(earth + "/" + smallRockVFX.name, 0.7f, new Vector3(0f, 0f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(earth + "/" + smallRockVFX.name, 0.7f, new Vector3(3f, 0f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(earth + "/" + ultimateThrowVFX.name, 0.7f, new Vector3(0f, -4f, 0f)));
                PlayAudio(ultimateThrowAudioClip, 0.5f);
                
                break;
            case "Long_Power_Hit":
                StartCoroutine(SpawnVFXWithDelay(earth + "/" + longPowerHitVFX.name, 0.3f, new Vector3(-1f, 0f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(earth + "/" + longPowerHitSlashVFX.name, 1.3f, new Vector3(0f, 0f, 0f)));
                PlayAudio(slashAudioClip, 1.3f);
                break;
            
            case "Power_Hit":
                
                
                StartCoroutine(SpawnVFXWithDelay(earth + "/" + powerHitVFX.name, 1.1f, new Vector3(0f, -4.42f, 0f)));
                PlayAudio(smashAudioClip, 1.3f);
                break;
            default:
                base.HandleVFX(combatAction);
                break;
        }
    }

    
}
