using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Player_Tag : MonoBehaviour
{
    GameObject player;
    string playerType;
    bool colorSet = false;

    public Image colorType;
    void Start()
    {
        playerType = PlayerPrefs.GetString("SelectedPlayerType", "Player_Fire");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");

        }
        
        gameObject.transform.position=new Vector3(player.transform.position.x,-7.8f,-1f);

        if (!colorSet)
        {
            SetColor();
        }

       

    }

    void SetColor()
    {
        if (playerType == "Player_Fire") { colorType.color = new Color(1f, 0.498f, 0f, 1f); colorSet = true; }
        if (playerType == "Player_Water") { colorType.color = new Color(0f, 0.478f, 1f, 1f); colorSet = true; }
        if (playerType == "Player_Lightning") { colorType.color = Color.white; colorSet = true; }
        if (playerType == "Player_Earth") { colorType.color = new Color(0.701f, 0.329f, 0.024f, 1f); colorSet = true; }

        
    }

}
