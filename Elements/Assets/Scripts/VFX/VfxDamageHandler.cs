using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


//this checks the collision with player and also set the damge of a particular vfx.
public class VfxDamageHandler : MonoBehaviour
{
    PhotonView vfxPV;
    string vfxOwner;

    [SerializeField]
    float vfxDamage;

    bool isTackle;
    private void Start()
    {
        vfxPV = GetComponent<PhotonView>();
        vfxOwner = vfxPV.Owner.ToString();

        if (gameObject.CompareTag("Tackle"))
        {
            isTackle = true;
        }
        else { isTackle= false; }
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        PhotonView playerPV = player.GetComponent<PhotonView>();
        
        string playerName=playerPV.Owner.ToString();

        if (playerName=="#02 'Player2'")
        {

            if (vfxOwner == "#01 'Player1'")
            {
                Debug.Log("Player1 attacked player 2");
                
                playerPV.RPC("TakeDamageRPC", RpcTarget.AllBuffered, playerName,vfxDamage,isTackle);

                

            }


        }
        else if(playerName == "#01 'Player1'")
        {
            if (vfxOwner == "#02 'Player2'")
            {
                Debug.Log("Player2 attacked player 1");
                
                playerPV.RPC("TakeDamageRPC", RpcTarget.AllBuffered, playerName,vfxDamage,isTackle);
                

            }

        }
        
    }
    
    
}
