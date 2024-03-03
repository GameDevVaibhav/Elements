using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    PhotonView photonView;
    public float currentHealth;
    public float maxHealth = 100f;
    public float currentDefenceHealth;
    public float maxDefenceHealth = 100f;

    Animator animator;
    bool isRecoveringDefence = false;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        currentDefenceHealth = maxDefenceHealth;
    }

    [PunRPC]
    public void TakeDamageRPC(string player, float damage, bool isTackle)
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
                else { ReduceDefenceHealth(damage); }
            }
            else
            {
                if (!IsDefending())
                {
                    currentHealth -= damage;
                    Debug.Log(player + " Took Damage " + damage);
                }
                else { ReduceDefenceHealth(damage); }
            }

            currentHealth = Mathf.Max(currentHealth, 0f);
            currentDefenceHealth = Mathf.Max(currentDefenceHealth, 0f);
        }
    }

    void ReduceDefenceHealth(float damage)
    {
        currentDefenceHealth -= damage;
        Debug.Log("Defence Health Reduce " + currentDefenceHealth);

        if (currentDefenceHealth <= 0 && !isRecoveringDefence)
        {
            StartCoroutine(StartRecoveringDefence());
        }
    }

    IEnumerator StartRecoveringDefence()
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds before starting the regeneration

        isRecoveringDefence = true;

        float duration = 5f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            currentDefenceHealth = Mathf.Lerp(0f, maxDefenceHealth, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        currentDefenceHealth = maxDefenceHealth;
        isRecoveringDefence = false;
    }

    bool IsDefending()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("Defence");
    }

    bool IsLowDefending()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("LowerDefence");
    }

}

