using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseVFX : MonoBehaviour
{
    
    public GameObject defaultVFX;
     public GameObject playerType;

    
    protected Combat combat;

    protected virtual void Start()
    {
        combat = FindObjectOfType<Combat>();
    }

    // HandleVFX method can be overridden in the derived classes for specific implementations
    public virtual void HandleVFX(string combatAction)
    {
        StartCoroutine(SpawnVFXWithDelay(defaultVFX, 0.5f, Vector3.zero));
    }

    protected IEnumerator SpawnVFXWithDelay(GameObject vfxPrefab, float delayDuration, Vector3 offset)
    {
        yield return new WaitForSeconds(delayDuration);

        // Instantiate the VFX at the position of the VFXSpawnner object
        GameObject spawnedVfx = Instantiate(vfxPrefab, transform.position + offset, Quaternion.identity);

    }
}
