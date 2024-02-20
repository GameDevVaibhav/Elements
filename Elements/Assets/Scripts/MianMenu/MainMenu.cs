using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class MainMenu : MonoBehaviour
{
    

    public void StartGame()
    {
        // Load the GameScene when the "Join" button is clicked
        SceneManager.LoadScene("GameScene");
    }

   
   
}
