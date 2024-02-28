using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaitingForPlayer : MonoBehaviour
{
    Player_Health[] players;
    public GameObject playUI;
    public GameObject player2;
    private bool hasWaited = false;

    public TextMeshProUGUI player1Name;
    public TextMeshProUGUI player2Name;

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

           // player2Name.text = player2.name; 
            StartCoroutine(WaitAndActivateUI(5f));
            hasWaited = true;
        }
    }

    IEnumerator WaitAndActivateUI(float seconds)
    {
        yield return new WaitForSeconds(seconds);

      
        playUI.SetActive(true);
        gameObject.SetActive(false);
    }
}
