using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BaseVFX : MonoBehaviour
{
    
    public string defaultVFX;
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




    protected IEnumerator SpawnVFXWithDelay(string vfxPrefab, float delayDuration, Vector3 offset)
    {
        yield return new WaitForSeconds(delayDuration);
        Vector3 localOffset=transform.TransformDirection(offset);
        GameObject spawnedVfx;

        

        if (vfxPrefab=="Power_Hit")
        {
            spawnedVfx = PhotonNetwork.Instantiate("VFX/"+vfxPrefab, offset, transform.rotation);
        }
        else
        {

            spawnedVfx = PhotonNetwork.Instantiate("VFX/"+vfxPrefab, transform.position + localOffset, transform.rotation);
            

        }

       

    }






}
