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
    private bool isAlerted;

    private float movespeed = 0.33f;

    private float moveTimer;
    public void Move(float diffx, float diffy, float time/*, float speedLimit = 10*/) 
    {//speed limit nu trebuie pt ca nu va functiona enemy pana cand nu ajunge player destul de aproape. Astfel nu exista riscul ca enemy sa zboare din capatul hartii spre player.
        
        
        float distance = Mathf.Sqrt(diffx * diffx + diffy * diffy);
        
        moveTimer = time;
        while (moveTimer > 0)
        {
            body.velocity = new Vector2(diffx, diffy) * (distance / time);
            moveTimer -= Time.deltaTime;
        }
        
        Debug.Log(Equals(body.velocity));
        /*if (body.velocity.magnitude > speedLimit) //aplicare a speed limitului. (nefolosita)
        {
            body.velocity.Normalize();
            body.velocity = body.velocity * speedLimit;
        }*/
    }
    private float repeatDelay;
    private Vector2 distanceToPlayer;
    private void Update()
    {
        distanceToPlayer = (playerBody.transform.position - body.transform.position) / 10;

        if (distanceToPlayer.magnitude < 0.75)
        {
            isAlerted = true;
        }

        if (repeatDelay < 0 && isAlerted)
        {
            randomposition = new Vector2(Random.value - 0.5f, Random.value - 0.5f) /2;
            Move(randomposition.x + distanceToPlayer.x, randomposition.y + distanceToPlayer.y + 0.75f, movespeed);
            Debug.Log("Angel moved: " + randomposition.x + distanceToPlayer.x+" "+(randomposition.y + distanceToPlayer.y));
            if (distanceToPlayer.magnitude > 1) 
            {
                repeatDelay = 2 / distanceToPlayer.magnitude;

            }
            else
            {
                repeatDelay = 1.18f;
            }

        }
        repeatDelay -= Time.deltaTime;
        
    }
}
