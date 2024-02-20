using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AttackRange : MonoBehaviour
{
    public float range = 2.0f;
    public Vector3 offset = Vector3.zero;

    Transform player;
    CircleCollider2D circleCollider;

    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        player = FindObjectOfType<PlayerController>().transform;
        float rotationY = player.rotation.eulerAngles.y;

        circleCollider.offset=  new Vector2(offset.x,offset.y);

        Debug.Log(circleCollider.offset);
    }
    void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position+offset, range);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PhotonView photonView = other.GetComponent<PhotonView>();

        if (photonView != null && photonView.IsMine)
        {
            // The collision is with the local player, do nothing.
        }
        else if (other.CompareTag("Player_Fire"))
        {
            Debug.Log("Opponent entered the attack range");
            // Add logic for applying damage or any other action for remote players.
        }
    }

  
}
