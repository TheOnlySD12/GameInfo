using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemy : MonoBehaviour
{

    public int maxHealth = 200;
    int currentHealth;
    public GameObject InamicFunctieDestroy;
    public float delayMoarte;
    public Animator animator;
    public Rigidbody2D body;
    public float bouncePower = 10f;


    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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

}
