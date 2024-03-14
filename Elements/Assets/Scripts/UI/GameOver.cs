using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon;

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
        // Only the Master Client checks the result
       // if (PhotonNetwork.IsMasterClient)
       

        
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


            // Call the AnnounceWinner method on all clients
            pv.RPC("AnnounceWinner", RpcTarget.All, player1Wins, isTie);
        }
    }

    // Call this method remotely on all clients
    [PunRPC]
    void AnnounceWinner(bool player1Wins, bool isTie)
    {
       // SetGameOverOnAllPlayers(true);
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

   

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        // When a player leaves the room, destroy their associated objects
        if (!PhotonNetwork.IsMasterClient)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            foreach (GameObject player in players)
            {
                PhotonView pv = player.GetComponent<PhotonView>();
                if (pv.Owner == otherPlayer)
                {
                    PhotonNetwork.Destroy(player);
                    break;
                }
            }
        }
    }
    public void LoadMainMenu()
    {
        photonView.RPC("LoadMainMenuRPC", RpcTarget.All);
    }

    [PunRPC]
    void LoadMainMenuRPC()
    {
        SceneManager.LoadScene(0);
    }

    public void RequestRematch()
    {
        // Check if current player is Player1 or Player2
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

        // If both players have requested a rematch, initiate rematch
        if (isPlayer1RematchRequested && isPlayer2RematchRequested)
        {
            Debug.Log("Rematch Confirmed");
           // SetGameOverOnAllPlayers(false);
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
        // Find both players and reset their health
        Player_Health[] players = FindObjectsOfType<Player_Health>();
        foreach (Player_Health player in players)
        {
            player.ResetHealth();
            player.GetComponent<PlayerController>().ResetPosition();
        }
    }

}
