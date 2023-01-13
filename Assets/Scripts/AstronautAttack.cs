using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautAttack : MonoBehaviour
{
    private bool playerInSight;
    public Transform firePoint;
    public GameObject bullet;

    public float timeRemaining = 3f;

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        if (playerInSight && timeRemaining <= 1)
        {
            Shoot();
        }
        
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInSight = true;

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInSight = false;

        }

    }
    void Shoot()
    {
        Debug.Log("Bullet");  
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        timeRemaining = 3f;
    }

}
