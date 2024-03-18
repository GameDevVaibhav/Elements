using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

//Sets the defence health and player health and also the time. 
public class Play_UI : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI healthPlayer1;
    public TextMeshProUGUI healthPlayer2;
    public Slider healthBarPlayer1;
    public Slider healthBarPlayer2;

    public Slider defenceHealth1;
    public Slider defenceHealth2;

    public Image timer;

    public GameObject gameOverUi;
    public GameObject opponentDisconnected;


    public float timerValue = 0f; 
    float maxTimerValue = 90f;


    float value1;
    float value2;

    string playerType;

    bool isMusicOn;
    public AudioSource music;
    Player_Health[] playersHealth;
    public GameOver gameOver;
    void Start()
    {
        playersHealth = FindObjectsOfType<Player_Health>();
        isMusicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;

        if (isMusicOn)
        {
            music.Play();
        }
        music.volume = PlayerPrefs.GetFloat("MusicVolume", 0.2f);

    }

    
    void Update()
    {

        Timer();
        HealthandDefenceBar();

    }

    
    void HealthandDefenceBar()
    {
        foreach (Player_Health player in playersHealth)
        {
            PhotonView pv = player.GetComponent<PhotonView>();
            if (pv.Owner.ToString() == "#01 'Player1'")
            {
                //healthPlayer1.text = player.currentHealth.ToString();
                value1 = player.currentHealth;
                defenceHealth1.value = player.currentDefenceHealth;

              
            }
            else
            {
               // healthPlayer2.text = player.currentHealth.ToString();
                value2 = player.currentHealth;
                defenceHealth2.value = player.currentDefenceHealth;
                

            }

            if (player.currentHealth <= 0)
            {
                // Set game over UI to true
                player.GetComponent<Animator>().SetBool("Death",true);
                gameOverUi.SetActive(true);

            }
            else { player.GetComponent<Animator>().SetBool("Death", false); }

        }



        healthBarPlayer1.value = Mathf.Lerp(healthBarPlayer1.value, value1, Time.deltaTime * 5);
        healthBarPlayer2.value = Mathf.Lerp(healthBarPlayer2.value, value2, Time.deltaTime * 5);

        
    }

    void Timer()
    {
        if (timerValue < maxTimerValue)
        {
            timerValue += Time.deltaTime;

            // Update the image fill amount based on the timer progress
            float fillAmount = timerValue / maxTimerValue;
            timer.fillAmount = fillAmount;
        }
        else
        {
            
            Debug.Log("Match is over!");

            gameOverUi.SetActive(true);
        }
    }

   public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        gameOverUi.SetActive(true);
        opponentDisconnected.SetActive(true) ;
    }


}
