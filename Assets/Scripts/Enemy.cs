using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.XR;

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

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform forwardGroundCheck;
 

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (IsGroundedForward())
        {
            Debug.Log("Astronaut: I can walk");
            transform.Translate(Vector2.left * Time.deltaTime);
        }
        
    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        animator.SetTrigger("Hit");
        if (currentHealth <= 0)
        {
            Die();
        }
        healthBar.SetHealth(currentHealth);
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
        healthBar.SetHealth(currentHealth);
    }

    private bool IsGroundedForward()
    {
        return Physics2D.OverlapCircle(forwardGroundCheck.position, 0f, groundLayer);
    }
    

}