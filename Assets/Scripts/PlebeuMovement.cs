using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlebeuMovement : MonoBehaviour
{
    Rigidbody2D body;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        if (GameObject.Find("Player") != null) { player = GameObject.Find("Player"); }
    }

    bool isAngered = false;
    bool isFacingRight = false;
    float timeUntilNextFlip;
    // Update is called once per frame
    void Update()
    {
        if ((transform.position - player.transform.position).magnitude < 4) { isAngered = true; }

        if (isAngered)
        {
            if (Mathf.Abs(body.velocity.x) < 6)
            {
                if (body.position.x < player.transform.position.x)
                {
                    body.AddForce(Vector2.right);
                }
                else
                {
                    body.AddForce(Vector2.left);
                }
            }
        }
        if (!isAngered)
        {
            timeUntilNextFlip -= Time.deltaTime;
            if (timeUntilNextFlip < 0)
            {
                timeUntilNextFlip = 3 + Random.value - 0.5f;//delay ~3s
                Flip();
            }

        }
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }
}
