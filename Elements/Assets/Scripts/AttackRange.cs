using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (rotationY != 0f)
        {
            
            offset.x = -offset.x;
        }
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
        if (other.CompareTag("Opponent"))
        {
            Debug.Log("Opponent entered the attack range");
            // Add logic for applying damage or any other action.
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Opponent"))
        {
            Debug.Log("Opponent exited the attack range");
            // Add logic for stopping damage or any other action.
        }
    }
}
