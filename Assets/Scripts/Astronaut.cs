using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.XR;

public class Astronaut : MonoBehaviour
{


    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform forwardGroundCheck;
 




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
    

}