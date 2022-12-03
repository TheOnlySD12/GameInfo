using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    public GameObject player;
    public float currentHealth;
    public float maxHealth = 30;
    public float damage = 10;

    private float invulnTimer = 0;
    private float damageFlashTimer = 0;

    private void Start() { currentHealth = maxHealth; }

    private void Update()
    {
        if (invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;
        }
        if (damageFlashTimer > 0)
        {
            damageFlashTimer -= Time.deltaTime;
        }
            
        if (invulnTimer > 0)
        {
            if (damageFlashTimer <= 0)
            {
                damageFlashTimer = 0.5f;
                player.GetComponent<Renderer>().enabled = !player.GetComponent<Renderer>().enabled;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && invulnTimer <= 0)
        {
            currentHealth -= damage;
            invulnTimer = 3;
            Debug.Log("damage!");
        }
    }
}
