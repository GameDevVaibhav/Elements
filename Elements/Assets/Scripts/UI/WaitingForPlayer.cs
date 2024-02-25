using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitingForPlayer : MonoBehaviour
{
    Player_Health[] playersHealth;
    public GameObject playUI;
    public GameObject player2;
    private bool hasWaited = false;

    void Start()
    {

    }

    void Update()
    {
        playersHealth = FindObjectsOfType<Player_Health>();

        if (playersHealth.Length == 2 && !hasWaited)
        {
            player2.SetActive(true);
            Debug.Log("Player Joined");

            
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
