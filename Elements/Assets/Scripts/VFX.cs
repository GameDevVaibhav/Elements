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
                StartCoroutine(SpawnVFXWithDelay(tackleVFX, 0.5f,Vector3.zero));
                break;
            case "Upper_Slash":
                StartCoroutine(SpawnVFXWithDelay(upperSlashVFX, 0.3f,Vector3.zero));
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
        }
    }

    private IEnumerator SpawnVFXWithDelay(GameObject vfxPrefab, float delayDuration,Vector3 offset)
    {
        // Wait for the specified delay duration
        yield return new WaitForSeconds(delayDuration);

        // Instantiate the VFX at the position of the VFXSpawnner object
        Instantiate(vfxPrefab, transform.position+offset, Quaternion.identity);

        
    }

    
    
}
