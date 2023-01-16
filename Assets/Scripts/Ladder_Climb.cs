using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder_Climb : MonoBehaviour
{

    private float vertical;
    private float speed = 8f;

    private bool isClimbing;
    private bool isLadder;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Rigidbody2D rb;


    public Animator animator;


    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        { 
            isClimbing = true;
            

        }
        if (isClimbing && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("JUMP");
            isClimbing = false;
            

        }

    }

    private void FixedUpdate()
    {
        
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
            animator.SetFloat("ClimbSpeed", Mathf.Abs(rb.velocity.y));
        }
        if (isClimbing && rb.velocity.y == 0)
        {
            animator.SetFloat("ClimbSpeed", 0.01f);
        }
        if (!isClimbing && !Movement.isDashing)
        {
            rb.gravityScale = 4f;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder") || IsGrounded())
        {
            isLadder = false;
            isClimbing = false;
            animator.SetFloat("ClimbSpeed", 0);
        }
        
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }
}
