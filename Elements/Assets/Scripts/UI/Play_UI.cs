using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Play_UI : MonoBehaviour
{
    public TextMeshProUGUI healthPlayer1;
    public TextMeshProUGUI healthPlayer2;
    public Slider healthBarPlayer1;
    public Slider healthBarPlayer2;

    public Slider defenceHealth1;
    public Slider defenceHealth2;

    float value1;
    float value2;

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
                value1 = player.currentHealth;
                defenceHealth1.value = player.currentdefenceHealth;
            }
            else
            {
                healthPlayer2.text = player.currentHealth.ToString();
                value2 = player.currentHealth;
                defenceHealth2.value = player.currentdefenceHealth;
               
            }
        }

        

        healthBarPlayer1.value = value1;
        healthBarPlayer2.value = value2;
        
    }
}
