using System.Collections;
using TMPro.Examples;
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

    public float FallingThreshold = -0.3f;

    //Dash variabile
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 9.8f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.3f;

    //Crouch variable
    public BoxCollider2D cCollider2D;
    public BoxCollider2D fBoxCollider2D;

    public Animator animator;


    void Start()
    {
        respawnPoint = transform.position;
        cCollider2D.enabled = false;
    }
    private void Awake()
    {



    }

    private void Update()
    {
        if (isDashing)
        {
            return;
        }
        Update(fallDetector);


        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("IsJumping", true);
        }

        if (rb.velocity.y < FallingThreshold)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", true);
        }
        else
        {
            animator.SetBool("IsFalling", false);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

        }
        if (Input.GetKeyDown(KeyCode.C) && canDash)
        {
            StartCoroutine(Dash());
            animator.SetTrigger("Dash");
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && IsGrounded())
        {
            speed = 4f;
            animator.SetBool("IsCrouching",true);
            cCollider2D.enabled = true;
            fBoxCollider2D.enabled = false;
      
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 8f;
            animator.SetBool("IsCrouching", false);
            fBoxCollider2D.enabled = true;
            cCollider2D.enabled = false;    
            
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
    private IEnumerator Dash()
    {
        animator.SetBool("IsJumping", false);
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower,0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

    }

        private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
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