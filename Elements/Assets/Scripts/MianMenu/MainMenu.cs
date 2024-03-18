using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

/*Includes all the Buttons and panels like create room will have map selection which is saved in playerprefs and also selected player.
 Also contains music toggle and volume slider*/
public class MainMenu : MonoBehaviour
{

    public GameObject createRoomPanel;
    public GameObject joinRoomPanel;
    public GameObject controlPanel;

    string selectedType;
    string selectedMap;
    private GameObject selectedMapButton;
    private GameObject selectedPlayerButton;
    private RectTransform selectedButtonTransform;

    private bool isMusicOn = true;
    public Toggle musicToggle;
    public AudioSource music;
    public Slider volume;

    void Start()
    {
        selectedMap = PlayerPrefs.GetString("SelectedMap", "Map_Fire");
        selectedType = PlayerPrefs.GetString("SelectedPlayerType", "Player_Fire");

        // Load music state from PlayerPrefs
        isMusicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1; 
        musicToggle.isOn = isMusicOn;

        
    }
    private void Update()
    {
        music.volume=volume.value;
        PlayerPrefs.SetFloat("MusicVolume", music.volume);
    }

    public void OnCreateRoomButtonClick()
    {
        createRoomPanel.SetActive(true);
        joinRoomPanel.SetActive(false);
        controlPanel.SetActive(false);
    }

    public void OnJoinRoomButtonClick()
    {
        createRoomPanel.SetActive(false);
        joinRoomPanel.SetActive(true);
        controlPanel.SetActive(false);
    }

    public void OnControlButtonClick()
    {
        controlPanel.SetActive(true);
        createRoomPanel.SetActive(false);
        joinRoomPanel.SetActive(false);
    }
    // Map buttons
    public void OnFireMapButtonClick()
    {
        DeselectMapButton(selectedMapButton);
        selectedMap = "Map_Fire";
        SaveSelectedMap();
        SelectMapButton(GameObject.Find("Fire_Map"));
    }

    public void OnWaterMapButtonClick()
    {
        DeselectMapButton(selectedMapButton);
        selectedMap = "Map_Water";
        SaveSelectedMap();
        SelectMapButton(GameObject.Find("Water_Map"));
    }

    public void OnEarthMapButtonClick()
    {
        DeselectMapButton(selectedMapButton);
        selectedMap = "Map_Earth";
        SaveSelectedMap();
        SelectMapButton(GameObject.Find("Earth_Map"));
    }

    public void OnLightningMapButtonClick()
    {
        DeselectMapButton(selectedMapButton);
        selectedMap = "Map_Lightning";
        SaveSelectedMap();
        SelectMapButton(GameObject.Find("Lightning_Map"));
    }

    // Player type buttons
    public void OnFireButtonClick()
    {
        DeselectPlayerButton(selectedPlayerButton);
        selectedType = "Player_Fire";
        SaveSelectedType();
        SelectPlayerButton(GameObject.Find("Fire"));
    }

    public void OnWaterButtonClick()
    {
        DeselectPlayerButton(selectedPlayerButton);
        selectedType = "Player_Water";
        SaveSelectedType();
        SelectPlayerButton(GameObject.Find("Water"));
    }

    public void OnLightningButtonClick()
    {
        DeselectPlayerButton(selectedPlayerButton);
        selectedType = "Player_Lightning";
        SaveSelectedType();
        SelectPlayerButton(GameObject.Find("Lightning"));
    }

    public void OnEarthButtonClick()
    {
        DeselectPlayerButton(selectedPlayerButton);
        selectedType = "Player_Earth";
        SaveSelectedType();
        SelectPlayerButton(GameObject.Find("Earth"));
    }

    void SaveSelectedType()
    {
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
        controlPanel.SetActive(false);
    }

    void SelectMapButton(GameObject button)
    {
        selectedMapButton = button;
        RectTransform buttonRect = button.GetComponent<RectTransform>();
        if (buttonRect != null)
        {
            buttonRect.localScale = new Vector3(1.2f, 1.2f, 1f);
        }
    }

    void SelectPlayerButton(GameObject button)
    {
        selectedPlayerButton = button;
        RectTransform buttonRect = button.GetComponent<RectTransform>();
        if (buttonRect != null)
        {
            buttonRect.localScale = new Vector3(1.2f, 1.2f, 1f);
        }
    }

    void DeselectMapButton(GameObject button)
    {
        if (button != null)
        {
            RectTransform buttonRect = button.GetComponent<RectTransform>();
            if (buttonRect != null)
            {
                buttonRect.localScale = new Vector3(1f, 1f, 1f); 
            }
        }
    }

    void DeselectPlayerButton(GameObject button)
    {
        if (button != null)
        {
            RectTransform buttonRect = button.GetComponent<RectTransform>();
            if (buttonRect != null)
            {
                buttonRect.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }


    public void ToggleMusic()
    {
        isMusicOn = musicToggle.isOn;

        // Save the music state to PlayerPrefs
        PlayerPrefs.SetInt("MusicOn", isMusicOn ? 1 : 0);
        PlayerPrefs.Save();

        if (isMusicOn)
        {
            music.Play();
        }
        else
        {
            music.Stop();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
