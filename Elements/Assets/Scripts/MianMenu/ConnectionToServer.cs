using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ConnectionToServer : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject mainMenu;
    public void Start()
    {
        // Connect to the Photon server when the MainMenu script starts
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("joined");
        mainMenu.SetActive(true);
    }
}
