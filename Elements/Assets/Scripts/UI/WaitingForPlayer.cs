using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


//after creation of room player1 will join and wait for player2. It sets the player intro videos and activate playerUI 

public class WaitingForPlayer : MonoBehaviour
{
    Player_Health[] players;
    public GameObject playUI;
    public GameObject player2;
    private bool hasWaited = false;

    



    public VideoPlayer videoPlayer1;
    public VideoPlayer videoPlayer2;

    [SerializeField] VideoClip vcFire;
    [SerializeField] VideoClip vcWater;
    [SerializeField] VideoClip vcLightning;
    [SerializeField] VideoClip vcEarth;

    public GameObject waitingScreenPanel;

    void Start()
    {
        
    }

    void Update()
    {
        players = FindObjectsOfType<Player_Health>();

        

        if (players.Length == 2 && !hasWaited)
        {
            player2.SetActive(true);
            

            Debug.Log("Player Joined");

            SettingClip();

            StartCoroutine(WaitAndPlay());

          
            StartCoroutine(WaitAndActivateUI(6f));
            hasWaited = true;
        }
    }

    void SettingClip()
    {
        foreach (Player_Health player in players)
        {
            PhotonView pv = player.GetComponent<PhotonView>();

            string playerName = pv.Owner.ToString();

            if (player.name == "Player_Fire(Clone)")
            {

                if (playerName == "#01 'Player1'")
                {
                    videoPlayer1.clip = vcFire;
                }
                else { videoPlayer2.clip = vcFire; }
            }
            if (player.name == "Player_Water(Clone)")
            {

                if (playerName == "#01 'Player1'")
                {
                    videoPlayer1.clip = vcWater;
                }
                else { videoPlayer2.clip = vcWater; }
            }
            if (player.name == "Player_Lightning(Clone)")
            {

                if (playerName == "#01 'Player1'")
                {
                    videoPlayer1.clip = vcLightning;
                }
                else { videoPlayer2.clip = vcLightning; }
            }
            if (player.name == "Player_Earth(Clone)")
            {

                if (playerName == "#01 'Player1'")
                {
                    videoPlayer1.clip = vcEarth;
                }
                else { videoPlayer2.clip = vcEarth; }
            }
        }
    }
    IEnumerator WaitAndPlay()
    {
        yield return new WaitForSeconds(1f);
        waitingScreenPanel.SetActive(false);
        videoPlayer1.Play();
        videoPlayer2.Play();
    }

    IEnumerator WaitAndActivateUI(float seconds)
    {
        yield return new WaitForSeconds(seconds);

      
        playUI.SetActive(true);
        gameObject.SetActive(false);
    }
}
