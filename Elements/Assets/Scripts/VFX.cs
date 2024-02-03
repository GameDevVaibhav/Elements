using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
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
    public GameObject crossSlashVFX;

    

    Combat combat;
    
    private void Start()
    {
        combat = FindObjectOfType<Combat>();
        
        
    }

    public void HandleVFX(string combatAction)
    {
        // Call the corresponding VFX method based on the combat action
        switch (combatAction)
        {
            case "Tackle":
                
                {
                    StartCoroutine(SpawnVFXWithDelay(tackleVFX, 0.5f, Vector3.zero));
                }
                
                
                break;
            case "Upper_Slash":
                
                
                    StartCoroutine(SpawnVFXWithDelay(upperSlashVFX, 0.3f, Vector3.zero));
                
                
                
                break;
            case "Smash":
                StartCoroutine(SpawnVFXWithDelay(smashVFX, 0.9f,Vector3.zero));
                break;
            case "Front_Slash":
                StartCoroutine(SpawnVFXWithDelay(frontSlashVFX, 0.5f,Vector3.zero));
                StartCoroutine(SpawnVFXWithDelay(frontSlash2VFX, 0.9f, Vector3.zero));
                break;
            case "Top-Bottom_Throw":
                StartCoroutine(SpawnVFXWithDelay(topBottomThrowVFX,0.3f,new Vector3(0f,5f,0f)));
                break;
            case "Spin_Kick":
                StartCoroutine(SpawnVFXWithDelay(Spin_KickVFX, 0.9f, new Vector3(0f, 0f, 0f)));
                break;
            case "Rock_Hit":
                StartCoroutine(SpawnVFXWithDelay(Rock_HitVFX, 0.7f, new Vector3(-3f, -2.5f, 0f)));
                break;
            case "Ultimate_Throw":
                Debug.Log("Ultimate_Throw");
                StartCoroutine(SpawnVFXWithDelay(ultimateThrowVFX, 0.7f, new Vector3(-3f, -2.5f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(ultimateThrowVFX, 0.5f, new Vector3(-2f, -2.5f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(ultimateThrowVFX, 0.4f, new Vector3(-1f, -2.5f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(ultimateThrowVFX, 0.7f, new Vector3(0f, -2.5f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(ultimateThrowVFX, 0.5f, new Vector3(1f, -2.5f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(ultimateThrowVFX, 0.4f, new Vector3(2f, -2.5f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(ultimateThrowVFX, 0.7f, new Vector3(3f, -2.5f, 0f)));
                break;
            case "Long_Power_Hit":
                StartCoroutine(SpawnVFXWithDelay(longPowerHitVFX, 0.3f, new Vector3(0f, 0f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(longPowerHitSlashVFX, 1.3f, new Vector3(0f, 0f, 0f)));
                break;
            case "Arrow_Throw":
                StartCoroutine(SpawnVFXWithDelay(arrowThrowVFX, 0.3f, new Vector3(0f, 0f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(arrowVFX, 0.5f, new Vector3(-3.5f, 0.4f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(arrowVFX, 0.8f, new Vector3(-3.5f, 0.4f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(arrowVFX, 1.5f, new Vector3(-3.5f, 0.4f, 0f)));
                StartCoroutine(SpawnVFXWithDelay(arrowVFX, 1.6f, new Vector3(-3.5f, 0.4f, 0f)));
                break;
            case "Cross_Slash":
                StartCoroutine(SpawnVFXWithDelay(crossSlashVFX, 1.2f, new Vector3(0f, 0f, 0f)));
                break;
        }
    }

    private IEnumerator SpawnVFXWithDelay(GameObject vfxPrefab, float delayDuration,Vector3 offset)
    {
        // Wait for the specified delay duration
        yield return new WaitForSeconds(delayDuration);

        // Instantiate the VFX at the position of the VFXSpawnner object
        GameObject spawnedVfx=Instantiate(vfxPrefab, transform.position+offset, Quaternion.identity);

        if(vfxPrefab==crossSlashVFX)
        {
            Destroy(spawnedVfx,1f);
        }

        
    }

    
    
}
