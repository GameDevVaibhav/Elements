using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lightning_Damage : MonoBehaviour
{
    public float damage;
    PhotonView vfxPV;
    string vfxOwner;

    PlayerController[] players;

    private void Start()
    {
        vfxPV = GetComponent<PhotonView>();
        vfxOwner = vfxPV.Owner.ToString();

        players = FindObjectsOfType<PlayerController>();

        GiveDamage();
    }

    void GiveDamage()
    {
        foreach (PlayerController player in players)
        {
            PhotonView playerPV = player.GetComponent<PhotonView>();
            string playerName = playerPV.Owner.ToString();
            if (vfxOwner == "#02 'Player2'")
            {
                if (playerPV.Owner.ToString() == "#01 'Player1'")
                {
                    playerPV.RPC("TakeDamageRPC", RpcTarget.OthersBuffered, playerName, damage, false);
                }
            }
            else if (vfxOwner == "#01 'Player1'")
            {
                if (playerPV.Owner.ToString() == "#02 'Player2'")
                {
                    playerPV.RPC("TakeDamageRPC", RpcTarget.OthersBuffered, playerName, damage, false);
                }
            }
        }

    }

}
