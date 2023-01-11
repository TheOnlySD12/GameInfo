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

    private float randomX;
    private float moveTimer;
    private void Update()
    {
        moveTimer -= Time.deltaTime;
        
        if (moveTimer < 0)
        {
            moveTimer = (Random.value + 0.5f) * 1.5f;
            randomX = (Random.value - 0.5f) * 50;

            Walk(randomX);
        }
        
        
    }

    

    private float moveDuration;
    void Walk(float x)
    {
        moveDuration = x;
        
        while(moveDuration > 0)
        {
            body.velocity = Vector2.right * x;
            moveDuration -= Time.deltaTime;
        }
        //body.velocity = Vector2.zero;
        Debug.Log("Astronaut moved");
    }
    
}