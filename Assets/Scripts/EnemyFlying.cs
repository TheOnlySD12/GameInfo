using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyFlying : MonoBehaviour
{
    public Rigidbody2D body;
    public Rigidbody2D playerBody;

    private Vector2 randomposition;

    public float movespeed = 0.33f;
    
    
    
    
    private float moveTimer;
    public void Move(float diffx, float diffy, float time)
    {
        
        
        float distance = Mathf.Sqrt(diffx * diffx + diffy * diffy);
        
        moveTimer = time;
        while (moveTimer > 0)
        {
            body.velocity = new Vector2(diffx, diffy) * (distance / time);
            moveTimer -= Time.deltaTime;
        }
        
        body.velocity = Vector2.zero;
        
        
    }
    private float repeatDelay;
    private Vector2 distanceToPlayer;
    private void Update()
    {
        distanceToPlayer = playerBody.transform.position - body.transform.position;

        if (repeatDelay < 0)
        {
            randomposition = new Vector2((Random.value - 0.5f) * 5, (Random.value - 0.5f) * 2);
            Move(randomposition.x + distanceToPlayer.x, randomposition.y + distanceToPlayer.y, movespeed);
            repeatDelay = 2;
            Debug.Log("Angel moved: " + randomposition.x + " " + randomposition.y);
        }
        repeatDelay -= Time.deltaTime;
        
    }
}
