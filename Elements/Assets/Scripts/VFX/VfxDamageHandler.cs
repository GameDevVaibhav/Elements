using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class VfxDamageHandler : MonoBehaviour
{
    PhotonView vfxPV;
    string vfxOwner;

    [SerializeField]
    float vfxDamage;
    private void Start()
    {
        vfxPV = GetComponent<PhotonView>();
        vfxOwner = vfxPV.Owner.ToString();
        
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
                playerPV.RPC("TakeDamageRPC", RpcTarget.AllBuffered, playerName,vfxDamage);
            }
            

        }
        else if(playerName == "#01 'Player1'")
        {
            if (vfxOwner == "#02 'Player2'")
            {
                Debug.Log("Player2 attacked player 1");
                playerPV.RPC("TakeDamageRPC", RpcTarget.AllBuffered, playerName,vfxDamage);
            }
           
        }
        
    }
}
