using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    //declaram variabile
    
    private float runSpeed = 7;
    private float jumpSpeed = 7;
    
    
    public bool isGrounded = true;

    public Rigidbody2D rb;
    //public BoxCollider2D col;
    void Update()
    {
        //movement
        
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * runSpeed, rb.velocity.y) ;
        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            isGrounded = false;
            
        }
        Debug.Log(rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.C))
        {
            //col.size.y = col.size.y / 2;
        }
        
        if (Physics2D.OverlapBox(new Vector2(0, 0 - transform.localScale.y / 2), new Vector2(transform.localScale.x / 100, transform.localScale.y / 100), 0, 8) == true)
        {
            isGrounded = true;
            Debug.Log("grounded");
        }

        //DE ADAUGAT CROUCH
        //Ar trebui sa faca collider-ul sa isi injumatateasca marimea y.
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
