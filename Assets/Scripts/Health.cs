using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Acest script nu mai este folosit, l-am pastrat doar in caz ca apar erori atunci cand il mut in PlayerCombat, unde este si acum.

    public int maxHealth = 200;
    int currentHealth;
    public GameObject InamicFunctieDestroy;
    public float delayMoarte;
    public Animator animator;
    public Rigidbody2D body;


    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeBulletDamage(int enemydamage)
    {

        currentHealth -= enemydamage;
        animator.SetTrigger("Hit");
        if (currentHealth <= 0)
        {
            Die();
            Destroy(gameObject);
        }
        healthBar.SetHealth(currentHealth);
    }

    void Die()
    {

        Debug.Log("Enemy died!");
        Destroy(InamicFunctieDestroy, delayMoarte);

    }


}