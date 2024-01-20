using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded;
    private Animator animator;
    SpriteRenderer r;
    BoxCollider2D collider;

    void Start()
    {
        // Get the Animator component.
        animator = GetComponent<Animator>();
        r = GetComponent<SpriteRenderer>();
        collider= GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
            
        }
        // 
        
       
        Vector2 S = r.sprite.bounds.size;
        collider.size = S;
        collider.offset= Vector2.zero;  
        

    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, jumpForce);
        isGrounded = false;

        // Trigger the Jump animation.
        animator.SetBool("isJumping", true);
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
