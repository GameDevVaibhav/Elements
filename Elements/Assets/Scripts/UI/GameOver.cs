using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Image result;
    public Sprite win;
    public Sprite lose;
    public Sprite tie;
    public Play_UI play_UI;

    // Call this method remotely on all clients
    [PunRPC]
    void AnnounceWinner(bool player1Wins, bool isTie)
    {
        if (isTie)
        {
            Debug.Log("It's a tie!");
            result.sprite=tie;
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

    // Start is called before the first frame update
    void Start()
    {
        // Only the Master Client checks the result
       // if (PhotonNetwork.IsMasterClient)
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

        SetGameOverOnAllPlayers(true);
    }

    void SetGameOverOnAllPlayers(bool isGameOver)
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            Combat combat=player.GetComponent<Combat>();

            if (playerController != null)
            {
                playerController.SetGameOver(isGameOver);
                combat.SetGameOver(isGameOver);
            }
        }
    }
}
