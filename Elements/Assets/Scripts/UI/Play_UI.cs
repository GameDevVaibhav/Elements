using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;

public class Play_UI : MonoBehaviour
{
    public TextMeshProUGUI healthPlayer1;
    public TextMeshProUGUI healthPlayer2;

    Player_Health[] playersHealth;
    void Start()
    {
        playersHealth = FindObjectsOfType<Player_Health>();
    }

    
    void Update()
    {
        
        
        foreach(Player_Health player in playersHealth)
        {
            PhotonView pv= player.GetComponent<PhotonView>();
            if(pv.Owner.ToString()== "#01 'Player1'")
            {
                healthPlayer1.text = player.currentHealth.ToString();
            }
            else
            {
                healthPlayer2.text = player.currentHealth.ToString();
            }
        }
    }
}
