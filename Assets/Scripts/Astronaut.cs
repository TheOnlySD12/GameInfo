using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.XR;
using Random = UnityEngine.Random;

public class Astronaut : MonoBehaviour
{


    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform forwardGroundCheck;
    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        moveTimer = (Random.value + 0.5f) * 1.5f;
        moveDuration = (Random.value + 0.5f) * 1.5f;
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
    private void Update()
    {
        moveTimer -= Time.deltaTime;
        
        if (moveTimer > 0)
        {
            body.velocity = new Vector2(3 * ((Convert.ToInt32(moveDirection) - 0.5f) * 2), body.velocity.y);  // convert transforma bool in int 0 sau 1
        }
        
        if (moveTimer <= 0)
        {
            body.velocity = new Vector2(0, body.velocity.y);
            
        }
        
        if(moveTimer <= -1)
        {
            moveTimer = Random.value * 2 + 1.5f;
            moveDirection = (Random.value - 0.5f) > 0;
        }
        
    }

    

    
    /*void Walk(float x)
    {
        moveDuration = Mathf.Abs(x);
        Debug.Log("moveDuration = " + moveDuration);
        while (moveDuration > 0)
        {
            body.velocity = Vector2.right * x;
            moveDuration -= Time.deltaTime;
        }
        //body.velocity = Vector2.zero;
        Debug.Log("Astronaut moved" + body.velocity.x);
    }*/
    
}