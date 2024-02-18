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
        Vector3 localOffset=transform.TransformDirection(offset);
        GameObject spawnedVfx;

        

        if (vfxPrefab.CompareTag("rock_power_hit"))
        {
            spawnedVfx = Instantiate(vfxPrefab, offset, transform.rotation);
        }
        else
        {

            spawnedVfx = Instantiate(vfxPrefab, transform.position + localOffset, transform.rotation);
            //AttackRange attackRange = spawnedVfx.GetComponent<AttackRange>();
            //if (attackRange != null)
            //{
            //    Debug.Log("found attack");
            //    attackRange.CheckForOpponentHits();
            //}
            
        }

    }
}
