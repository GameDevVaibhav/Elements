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
    

    public GameObject createRoomPanel;
    public GameObject joinRoomPanel;

   

    string selectedType;
    string selectedMap;

    void Start()
    {


        selectedMap = PlayerPrefs.GetString("SelectedMap", "Map_Fire");
        selectedType = PlayerPrefs.GetString("SelectedPlayerType", "Player_Fire");
    }

    public void OnCreateRoomButtonClick()
    {
        createRoomPanel.SetActive(true);
        joinRoomPanel.SetActive(false);
    }

    public void OnJoinRoomButtonClick()
    {
        createRoomPanel.SetActive(false);
        joinRoomPanel.SetActive(true);
    }

    public void OnFireMapButtonClick()
    {
        selectedMap = "Map_Fire";
        SaveSelectedMap();
    }
    public void OnWaterMapButtonClick()
    {
        selectedMap = "Map_Water";
        SaveSelectedMap();
    }
    public void OnEarthMapButtonClick()
    {
        selectedMap = "Map_Earth";
        SaveSelectedMap();
    }
    public void OnLightningMapButtonClick()
    {
        selectedMap = "Map_Lightning";
        SaveSelectedMap();
    }
    public void OnFireButtonClick()
    {
        selectedType = "Player_Fire";
        SaveSelectedType();
    }

    public void OnWaterButtonClick()
    {
        selectedType = "Player_Water";
        SaveSelectedType();
    }

    public void OnLightningButtonClick()
    {
        selectedType = "Player_Lightning";
        SaveSelectedType();
    }

   public  void OnEarthButtonClick()
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

    void SaveSelectedMap()
    {
        PlayerPrefs.SetString("SelectedMap", selectedMap);
        PlayerPrefs.Save();
    }

    public void ClosePanel()
    {
        createRoomPanel.SetActive(false);
        joinRoomPanel.SetActive(false);
    }
}
