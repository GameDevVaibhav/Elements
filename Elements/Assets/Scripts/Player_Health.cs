using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    PhotonView photonView;
    public float currentHealth;
    public float maxHealth = 100f;
    public float currentdefenceHealth;
    public float maxDefenceHealth=100f;

    Animator animator;
    public bool defence;
    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        currentdefenceHealth = maxDefenceHealth;
    }

    [PunRPC]
    public void TakeDamageRPC(string player,float damage,bool isTackle)
    {
        
        if (player == photonView.Owner.ToString())
        {
            if (isTackle)
            {
                if (!IsLowDefending())
                {
                    currentHealth -= damage;
                    Debug.Log(player + " Took Damage " + damage);
                }
                else { currentdefenceHealth -= damage; Debug.Log("Defence Health Reduce "+currentdefenceHealth); }
            }
            else 
            {
                if(!IsDefending())
                {
                    currentHealth -= damage;
                    Debug.Log(player + " Took Damage " + damage);
                }
                else { currentdefenceHealth -= damage; Debug.Log("Defence Health Reduce "+currentdefenceHealth); }
            }

            currentHealth = Mathf.Max(currentHealth, 0f);
            currentdefenceHealth=Mathf.Max(currentdefenceHealth, 0f);
        } 
    }

    bool IsDefending()
    {
        defence = true;
        return animator.GetCurrentAnimatorStateInfo(0).IsName("Defence");
    }

    bool IsLowDefending()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("LowerDefence");
    }

  
}

