using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    PhotonView photonView;
    public float currentHealth;
    public float maxHealth = 100f;

    Animator animator;
    public bool defence;
    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
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
                else { }
            }
            else 
            {
                if(!IsDefending())
                {
                    currentHealth -= damage;
                    Debug.Log(player + " Took Damage " + damage);
                }
                else { }
            }

            currentHealth = Mathf.Max(currentHealth, 0f);
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

