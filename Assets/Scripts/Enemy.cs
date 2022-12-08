using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public int maxHealth = 200;
    int currentHealth;
    public GameObject InamicFunctieDestroy;
    public float delayMoarte;
    public Animator animator;
    public Rigidbody2D body;
    public float moveSpeed;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        animator.SetTrigger("Hit");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        Debug.Log("Enemy died!");
        Destroy(InamicFunctieDestroy, delayMoarte);

    }
    
    private float moveTimer = 0;
    public void Move(float diffx, float moveDuration)
    {


        

        moveTimer = moveDuration;
        if (moveTimer > 0)
        {
            body.velocity = Vector2.right * (diffx / moveDuration);
            moveTimer -= Time.deltaTime;
        }
        else
        {
            body.velocity = Vector2.zero;
        }
    }

    private float repeatDelay;
    private float randomPosition;
    private void Update()
    {
        if (repeatDelay < 0)
        {
            randomPosition = (UnityEngine.Random.value - 0.5f) * 2;
            Move(randomPosition, moveSpeed);
            repeatDelay = 2;
            Debug.Log("Astronaut moved: " + randomPosition);
        }
        repeatDelay -= Time.deltaTime;

    }
}