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
    private float bouncePower = 10f;

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
    
    public void TakeUpDamage(int damage)
    {
        currentHealth -= damage;
        body.velocity = new Vector2(body.velocity.x, bouncePower);
        animator.SetTrigger("Hit");
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
}