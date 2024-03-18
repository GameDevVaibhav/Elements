using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using static UnityEngine.GraphicsBuffer;


//This instantiate VFX from resources folder using name. This class is extended by orther vfx classes which passes the vfxname.
public class BaseVFX : MonoBehaviourPun
{
    
    public string defaultVFX;
     public GameObject playerType;
    PhotonView vfxPV;

    protected Combat combat;

    Transform target;

    protected AudioSource audioSource;

    

    protected virtual void Start()
    {
        
        combat = FindObjectOfType<Combat>();
        audioSource = GetComponent<AudioSource>();


    }

    
    public virtual void HandleVFX(string combatAction)
    {
        StartCoroutine(SpawnVFXWithDelay(defaultVFX, 0.5f, Vector3.zero));
    }

  
    protected IEnumerator SpawnVFXWithDelay(string vfxPrefab, float delayDuration, Vector3 offset)
    {
        yield return new WaitForSeconds(delayDuration);
        Vector3 localOffset=transform.TransformDirection(offset);
        GameObject spawnedVfx;

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(players.Length);
        
        FindTarget(players);
        

        if (vfxPrefab== "Earth/Power_Hit")
        {
           
            spawnedVfx = PhotonNetwork.Instantiate("VFX/"+vfxPrefab, target.position,Quaternion.Euler(0f,0f,0f) );
        }
        else
        {

            spawnedVfx = PhotonNetwork.Instantiate("VFX/"+vfxPrefab, transform.position + localOffset, transform.rotation);
            
        }

      

    }

   

    void FindTarget(GameObject[] players)
    {
        PhotonView pv = GetComponentInParent<PhotonView>();

        if (pv == null)
        {
            Debug.Log("pv not set");
        }

        foreach (GameObject player in players)
        {
            PhotonView playerPV = player.GetComponent<PhotonView>();
            Debug.Log(player.gameObject.transform.position);

            if (pv.Owner.ToString() == "#02 'Player2'")
            {
                if (playerPV.Owner.ToString() == "#01 'Player1'")
                {
                    target= player.gameObject.transform;
                }
               

            }else if(pv.Owner.ToString()== "#01 'Player1'")
            {
                if (playerPV.Owner.ToString() == "#02 'Player2'")
                {
                    target = player.gameObject.transform;
                }
            }



        }
    }



}
