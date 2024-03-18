using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using Photon.Realtime;



//Creating room and joining room.
public class CreateAndJoin : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    public TextMeshProUGUI notification;



    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(createInput.text))
        {
            Debug.Log("ID cannot be empty");
            Notification("ID cannot be empty!");
            StartCoroutine(HideNotification());
            return;
        }
        PhotonNetwork.CreateRoom(createInput.text,new RoomOptions { MaxPlayers = 2 });
    }

    public void JoinRoom()
    {
        if (string.IsNullOrEmpty(joinInput.text))
        {
            Debug.Log("ID cannot be empty");
            Notification("ID cannot be empty!");
            StartCoroutine(HideNotification());
            return;
        }
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Play");
    }

    void Notification(string message)
    {
        notification.text = message;
        notification.gameObject.SetActive(true);
        
    }
    IEnumerator HideNotification()
    {
        yield return new WaitForSeconds(3f);
        notification.gameObject.SetActive(false);
    }
}
