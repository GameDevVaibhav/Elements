using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon;

//Handles gameover scenerios like annoucing winner and if player wants to leave room or request for rematch. If requested for rematch then reset the health of players.
public class GameOver : MonoBehaviourPunCallbacks
{
    public Image result;
    public Sprite win;
    public Sprite lose;
    public Sprite tie;
    public Play_UI play_UI;

    public GameObject rematchButton;
    bool isPlayer1RematchRequested = false;
    bool isPlayer2RematchRequested = false;

    float maxTimerValue = 90f;

    bool isRematchRequested = false;

   

    // Start is called before the first frame update
    void Start()
    {
      
       

        
    }

    private void Update()
    {
        SetResult();
    }
    public void SetResult()
    {
        {
            PhotonView pv = GetComponent<PhotonView>();

            string pvOwner = pv.Owner.ToString();
            bool player1Wins = false;
            bool isTie = false;


            {
                float healthDiff = play_UI.healthBarPlayer1.value - play_UI.healthBarPlayer2.value;
                player1Wins = (healthDiff > 0);
                isTie = (healthDiff == 0);

            }


            
            pv.RPC("AnnounceWinner", RpcTarget.All, player1Wins, isTie);
        }
    }

    
    [PunRPC]
    void AnnounceWinner(bool player1Wins, bool isTie)
    {
       
        if (isTie)
        {
            Debug.Log("It's a tie!");
            result.sprite = tie;
        }
        else if (player1Wins)
        {
            if (PhotonNetwork.IsMasterClient)
                result.sprite = win;
            else
                result.sprite = lose;

            Debug.Log("Player1 won!");
        }
        else
        {
            if (PhotonNetwork.IsMasterClient)
                result.sprite = lose;
            else
                result.sprite = win;

            Debug.Log("Player2 won!");
        }
    }

   

    
    public void LoadMainMenu()
    {
        photonView.RPC("LoadMainMenuRPC", RpcTarget.All);
    }

    [PunRPC]
    void LoadMainMenuRPC()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel(0);
    }

    public void RequestRematch()
    {
        
        if (PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("SetRematchRequest", RpcTarget.Others, true);
            isPlayer1RematchRequested = true;
        }
        else
        {
            photonView.RPC("SetRematchRequest", RpcTarget.MasterClient, true);
            isPlayer2RematchRequested = true;
        }

        
        if (isPlayer1RematchRequested && isPlayer2RematchRequested)
        {
            Debug.Log("Rematch Confirmed");
           
            photonView.RPC("HandleRematch", RpcTarget.All);
            isPlayer1RematchRequested = false;
            isPlayer2RematchRequested = false;
        }
    }

    [PunRPC]
    void SetRematchRequest(bool isRequested)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            isPlayer2RematchRequested = isRequested;
        }
        else
        {
            isPlayer1RematchRequested = isRequested;
        }
    }

    [PunRPC]
    public void HandleRematch()
    {
        Debug.Log("Rematch Called");
        ResetPlayersHealth();
        
        isPlayer1RematchRequested=false;
        isPlayer2RematchRequested=false;

        ResetTimer();
        
        gameObject.SetActive(false);
        
    }

    void ResetTimer()
    {
        play_UI.timerValue = 0f;
        play_UI.timer.fillAmount = 0f;
    }

    void ResetPlayersHealth()
    {
        
        Player_Health[] players = FindObjectsOfType<Player_Health>();
        foreach (Player_Health player in players)
        {
            player.ResetHealth();
            player.GetComponent<PlayerController>().ResetPosition();
        }
    }

}
