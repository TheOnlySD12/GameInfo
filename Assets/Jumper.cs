using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    Rigidbody2D body;
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    float timeUntilNextJump;
    // Update is called once per frame
    void Update()
    {
        timeUntilNextJump -= Time.deltaTime;
        if (timeUntilNextJump < 0)
        {
            timeUntilNextJump = 1;
            body.velocity = new Vector2((Random.value - 0.5f) * 3, 4);
        }
    }
}
