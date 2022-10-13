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
        //DE ADAUGAT GROUNDCHECK:
        //pentru performanta ca sa nu dea check la fiecare frame, verifican daca are ceva sub el doar cand atinge alt collider.
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        if (Physics2D.OverlapBox(new Vector2(0, transform.localScale.y/2-transform.localScale.y), new Vector2(transform.localScale.x, transform.localScale.y*100), 0) == true)
        {
            isGrounded = true;
            Debug.Log("grounded");
        }
    }
}
