using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private Vector3 respawnPoint;
    public GameObject fallDetector;

    private void Start()
    {
        respawnPoint = transform.position;
    }

    private void Update()
    {
        Update(fallDetector);
    }

    private void Update(GameObject fallDetector)
    {
        fallDetector.transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;

        }
        //if (collision.tag == "NextLevelPlace")
        // {
        //      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // }
    }
}
