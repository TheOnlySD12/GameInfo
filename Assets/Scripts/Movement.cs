using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{




    bool facingRight;

    private Vector3 respawnPoint;
    public GameObject fallDetector;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private float horizontal;


    public Animator animator;


    void Start()
    {
        respawnPoint = transform.position;
    }
    private void Awake()
    {
    
    }

    private void Update()
    {
        Update(fallDetector);

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }


    }

    private void Update(GameObject fallDetector)
    {

      
        if (Input.GetAxisRaw("Horizontal") < 0 && !facingRight)
        {         // se intoarce stanaga/ dreapta
            Flip();

        }
        if (Input.GetAxisRaw("Horizontal") > 0 && facingRight)        // se intoarce stanaga/ dreapta
        {
            Flip();
        }

        fallDetector.transform.position = new Vector2(transform.position.x, transform.position.y);




    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;

        }
        //if (collision.tag == "NextLevelPlace")
        //  {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // }
    }





    void Flip()
    {

        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;    //flip stanga dreapta
    }
}