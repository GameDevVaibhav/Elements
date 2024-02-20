using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D collider;

    // Reference to the opponent
     GameObject opponent;
    bool opponentFound = false;

    void Start()
    {
        // Get the Animator component.
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        
    }

    void Update()
    {
        if (!opponentFound)
        {
            FindOpponent();
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded && IsCurrentAnimation("Idle"))
        {
            Jump();
        }

        // Set player's rotation based on opponent's position
       
        {
            FlipTowardsOpponent();
        }

        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
        collider.size = spriteSize;
        collider.offset = Vector2.zero;
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, jumpForce);
        isGrounded = false;

        // Trigger the Jump animation.
        animator.SetBool("isJumping", true);
    }

    private bool IsCurrentAnimation(string animationName)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(animationName);
    }

    void FindOpponent()
    {
        // Find all objects with the "Player_Fire" tag
        GameObject[] playerFireObjects = GameObject.FindGameObjectsWithTag("Player_Fire");

        // Find the opponent with isMine set to false
        foreach (GameObject playerFireObject in playerFireObjects)
        {
            PhotonView opponentPhotonView = playerFireObject.GetComponent<PhotonView>();

            if (opponentPhotonView != null && !opponentPhotonView.IsMine)
            {
                opponent = playerFireObject;
                opponentFound = true; // Set the flag to true once the correct opponent is found
                break; // Stop searching once the correct opponent is found
            }
        }
    }
    void FlipTowardsOpponent()
    {
        if (opponent != null)
        {
            PhotonView opponentPhotonView = opponent.GetComponent<PhotonView>();

            if (opponentPhotonView != null && !opponentPhotonView.IsMine)
            {
                // Opponent is not the local player, flip the player to face the opponent
                float playerX = transform.position.x;
                float opponentX = opponent.transform.position.x;

                if (playerX < opponentX)
                {
                    // Opponent is on the right side, flip the player
                    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }
                else
                {
                    // Opponent is on the left side, flip the player
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
            }
        }
    }

    public void OnGround()
    {
        animator.SetBool("isJumping", false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            OnGround();
        }
    }
}
