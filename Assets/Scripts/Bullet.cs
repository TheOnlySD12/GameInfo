using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor.PackageManager;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D body;
    public int bulletDamage;

    void Start()
    {

        body.velocity = transform.right * speed;
        
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Health player = hitInfo.GetComponent<Health>();
        if (player != null)
        {
            player.TakeBulletDamage(bulletDamage);
        }
        if (hitInfo.CompareTag("Player") || hitInfo.CompareTag("Ground"))
        {
            Destroy(gameObject);

        }

    }

}
