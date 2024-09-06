using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 8f;
    public float jumpPower = 16f;
    private float hor;
    private bool facingRight = true;
   
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    
    void Update()
    {
        hor = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown("up") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        if (Input.GetKeyDown("up") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y*0.5f);
        }
        
        Flip();
    }
    
    void FixedUpdate()
    {
        rb.velocity = new Vector2(hor * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (facingRight && hor < 0f || !facingRight && hor > 0f)
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            Debug.Log("flipped");
        }
        
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        
    }
}