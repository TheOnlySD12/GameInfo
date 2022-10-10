using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    //declaram variabile
    
    public float runSpeed;
    public float jumpSpeed;
    //public bool isGrounded = true;

    public Rigidbody2D rb;
    
    void Update()
    {
        //movement
        
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * runSpeed, rb.velocity.y) ;
        if (Input.GetButton("Jump") /*&& isGrounded*/)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            //isGrounded = false;
        }
        //DE ADAUGAT GROUNDCHECK:
        //pentru performanta ca sa nu dea check la fiecare frame, verifican daca are ceva sub el doar cand atinge alt collider.
    }
}
