using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.XR;
using Random = UnityEngine.Random;

public class Astronaut : MonoBehaviour
{


    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform forwardGroundCheck;
    private Rigidbody2D body;

    public Animator animator;
    bool facingRight;
    List<Collider2D> wallsInFrontOf;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        moveTimer = (Random.value + 0.5f) * 1.5f;
        moveDuration = (Random.value + 0.5f) * 1.5f;
        wallsInFrontOf = new List<Collider2D>();
    }
    
    private void FixedUpdate()
    {
        if (IsGroundedForward())
        {
            Debug.Log("Astronaut: I can walk");
            transform.Translate(Vector2.left * Time.deltaTime);

        }
        
    }
    private bool IsGroundedForward()
    {
        return Physics2D.OverlapCircle(forwardGroundCheck.position, 0f, groundLayer);
    }

    private float moveTimer;
    private float moveDuration;
    private bool moveDirection;// 1 = positive x, -1 = negative x
    private float directionBalancer;
    private void Update()
    {
         

        if (Convert.ToInt32(moveDirection) <= 0 && !facingRight)
        {         // se intoarce stanaga/ dreapta
            Flip();

        }
        if (Convert.ToInt32(moveDirection) > 0 && facingRight)        // se intoarce stanaga/ dreapta
        {
            Flip();
        }


        moveTimer -= Time.deltaTime;
        
        if (moveTimer > 0)
        {
            body.velocity = new Vector2(3 * ((Convert.ToInt32(moveDirection) - 0.5f) * 2), body.velocity.y); // convert transforma bool in int 0 sau 1
            //Debug.Log("Astronaut moved: " + body.velocity.x + ". Is facing right? " + moveDirection + ". new average movement direction value: "+ directionBalancer/2);
        }
        
        if (moveTimer <= 0)
        {
            body.velocity = new Vector2(0, body.velocity.y);
            
        }
        
        if(moveTimer <= -1)
        {
            moveTimer = Random.value * 2 + 1.5f;
            
            
            moveDirection = (Random.value - 0.5f + directionBalancer/4) > 0;
            directionBalancer = 0 - (Convert.ToInt32(moveDirection) - 0.5f) * 2;
        }
        animator.SetFloat("Speed", Mathf.Abs(body.velocity.x));

        Debug.Log(wallsInFrontOf);

    }
    private void OnTriggerStay2D(Collider2D wallSeen)
    {
        if(wallSeen != null)
        {
            wallsInFrontOf.Add(wallSeen);
        }
        
        
        
    }
    private void OnTriggerExit2D(Collider2D wallGone)
    {
        wallsInFrontOf.Remove(wallGone); //cum scot colliderele din lista odata ce nu mai ating trigger-ul?????
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (wallsInFrontOf.Contains(collision.collider))
        {
            Flip();
            moveDirection = !moveDirection;
        }
    }

    private void Flip()
    {

        facingRight = !facingRight;
        //flip stanga dreapta
        transform.Rotate(0f,180f,0f);
    }
    
    
    
}