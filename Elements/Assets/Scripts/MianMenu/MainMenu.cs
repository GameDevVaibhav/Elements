using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Button Fire;
   public Button Water;
   public Button Lightning;
   public Button Earth;

    string selectedType;

    void Start()
    {
        // Assuming you have references to your buttons
        Fire.onClick.AddListener(OnFireButtonClick);
        Water.onClick.AddListener(OnWaterButtonClick);
        Lightning.onClick.AddListener(OnLightningButtonClick);
        Earth.onClick.AddListener(OnEarthButtonClick);

        // Load the previously selected type from PlayerPrefs (default to Player_Fire if not found)
        selectedType = PlayerPrefs.GetString("SelectedPlayerType", "Player_Fire");
    }

    void OnFireButtonClick()
    {
        selectedType = "Player_Fire";
        SaveSelectedType();
    }

    void OnWaterButtonClick()
    {
        selectedType = "Player_Water";
        SaveSelectedType();
    }

    void OnLightningButtonClick()
    {
        selectedType = "Player_Lightning";
        SaveSelectedType();
    }

    void OnEarthButtonClick()
    {
        selectedType = "Player_Earth";
        SaveSelectedType();
    }

    void SaveSelectedType()
    {
        // Save the selected type to PlayerPrefs
        PlayerPrefs.SetString("SelectedPlayerType", selectedType);
        PlayerPrefs.Save();
    }
}
