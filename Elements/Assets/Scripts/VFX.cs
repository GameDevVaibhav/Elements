using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{

    public GameObject tackleVFX;
    public GameObject upperSlashVFX;

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

    private IEnumerator SpawnVFXWithDelay(GameObject vfxPrefab,float delayDuration)
    {
        // Wait for the specified delay duration
        yield return new WaitForSeconds(delayDuration);

        // Instantiate the VFX at the position of the VFXSpawnner object
        Instantiate(vfxPrefab, transform.position, Quaternion.identity);
    }
}
