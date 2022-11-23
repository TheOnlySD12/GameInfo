using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyFlying : MonoBehaviour
{
    public Rigidbody2D body;


    private Vector2 randomposition;

    public float movespeed = 0.33f;
    
    
    
    
    private float moveTimer;
    public void Move(float diffx, float diffy, float time)
    {
        
        
        float distance = Mathf.Sqrt(diffx * diffx + diffy * diffy);
        
        moveTimer = time;
        if (moveTimer > 0)
        {
            body.velocity = new Vector2(diffx, diffy) * (distance / time);
            moveTimer -= Time.deltaTime;
        }
        else
        {
            body.velocity = Vector2.zero;
        }
    }
    private float repeatDelay;
    private void Update()
    {
        if (repeatDelay < 0)
        {
            randomposition = new Vector2((Random.value - 0.5f) * 2, (Random.value - 0.5f) * 2);
            Move(randomposition.x, randomposition.y, movespeed);
            repeatDelay = 2;
            Debug.Log("moved: " + randomposition.x + " " + randomposition.y);
        }
        repeatDelay -= Time.deltaTime;
        
    }
}
