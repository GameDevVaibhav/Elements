using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    PhotonView photonView;
    public float currentHealth;
    public float maxHealth = 100f;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        currentHealth = maxHealth;
    }

    [PunRPC]
    public void TakeDamageRPC(string player,float damage)
    {
        if (player == photonView.Owner.ToString())
        {
            currentHealth -= damage;
            Debug.Log(player + " Took Damage "+damage);

        } 
    }

}

