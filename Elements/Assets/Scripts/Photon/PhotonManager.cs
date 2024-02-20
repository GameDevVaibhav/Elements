using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PhotonManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 2 }, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        // Set the nickname for the local player based on view ID
        PhotonNetwork.NickName = "Player" + PhotonNetwork.LocalPlayer.ActorNumber;

        // Instantiate the player with the specified nickname
        GameObject player = PhotonNetwork.Instantiate("Player_Fire", new Vector2(0f, 0f), Quaternion.identity);

        // You may also want to customize the player's nickname locally for display purposes
        player.GetComponent<PhotonView>().Owner.NickName = PhotonNetwork.NickName;
    }
}
