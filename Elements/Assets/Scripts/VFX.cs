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

    // Example delay duration
    

    // ...

    // Example usage: Tackle()
    public void Tackle()
    {
        StartCoroutine(SpawnVFXWithDelay(tackleVFX,0.5f));
    }

    // Example usage: Upper_Slash()
    public void Upper_Slash()
    {
        StartCoroutine(SpawnVFXWithDelay(upperSlashVFX,0.3f));
    }
    public void Smash()
    {
        StartCoroutine(SpawnVFXWithDelay(smashVFX, 0.9f));
    }

    public void Front_Slash()
    {
        StartCoroutine(SpawnVFXWithDelay(frontSlashVFX, 0.5f));
        StartCoroutine(SpawnVFXWithDelay(frontSlash2VFX, 0.9f));
    }



    private IEnumerator SpawnVFXWithDelay(GameObject vfxPrefab,float delayDuration)
    {
        // Wait for the specified delay duration
        yield return new WaitForSeconds(delayDuration);

        // Instantiate the VFX at the position of the VFXSpawnner object
        Instantiate(vfxPrefab, transform.position, Quaternion.identity);
    }
}
