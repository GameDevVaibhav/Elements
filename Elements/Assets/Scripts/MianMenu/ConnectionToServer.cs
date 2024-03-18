using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;


//For connecting to Photon Server. And displaying the connection status.
public class ConnectionToServer : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI connectionStatus;

    public void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Update()
    {
        PhotonNetwork.ConnectUsingSettings();

        if(PhotonNetwork.NetworkClientState.ToString()== "ConnectedToMasterServer")
        {
            connectionStatus.text = "connected";
            
        }
        else
        {
            connectionStatus.text = "disconnected";
            
        }
        
        Debug.Log(connectionStatus.text);
    }

    







}
