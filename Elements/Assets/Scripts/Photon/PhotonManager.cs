using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Unity.VisualScripting;
public class PhotonManager : MonoBehaviourPunCallbacks
{
    string playerType;

    void Start()
    {
        Debug.Log("on joined room");

        playerType = PlayerPrefs.GetString("SelectedPlayerType","Player_Fire");
        // Set the nickname for the local player based on view ID
        PhotonNetwork.NickName = "Player" + PhotonNetwork.LocalPlayer.ActorNumber;

        float spawnX = PhotonNetwork.IsMasterClient ? -13f : 13f;
        GameObject player = PhotonNetwork.Instantiate(playerType, new Vector2(spawnX, 0f), Quaternion.identity);

        // You may also want to customize the player's nickname locally for display purposes
        player.GetComponent<PhotonView>().Owner.NickName = PhotonNetwork.NickName;
    }
}
