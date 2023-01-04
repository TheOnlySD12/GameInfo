using System.Collections;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{




    bool facingRight;

    public Transform respawnPoint;
    public GameObject fallDetector;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private BoxCollider2D BoxCollider2D;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform groundCheck2;
    [SerializeField] private LayerMask groundLayer;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private float horizontal;

    public float FallingThreshold = -0.3f;

    //Jump fancy variabile
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;
    //Dash variabile
    private bool canDash = true;
    public static bool isDashing;
    private float dashingPower = 9.8f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.3f;

    public Transform ceelingCheck;

    public Animator animator;


    void Start()
    {


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


        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if (Input.GetButtonDown("Jump") && !UnderCeiling())
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("IsJumping", true);
            jumpBufferCounter = 0f;
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
            coyoteTimeCounter = 0;
        }
        if (Input.GetKeyDown(KeyCode.C) && canDash)
        {
            StartCoroutine(Dash());
            animator.SetTrigger("Dash");
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && IsGrounded())
        {
            speed = 4f;
            animator.SetBool("IsCrouching", true);
            BoxCollider2D.size = new Vector2(0.5124145f, 0.6913913f);
            BoxCollider2D.offset = new Vector2(-0.0112071f, -0.2856956f);

        }
        if (!UnderCeiling() && !Input.GetKey(KeyCode.LeftShift))
        {
            speed = 8f;
            animator.SetBool("IsCrouching", false);
            BoxCollider2D.size = new Vector2(0.3790072f, 0.9818009f);
            BoxCollider2D.offset = new Vector2(-0.01607659f, -0.1423518f);
        }

        if (Input.GetAxisRaw("Horizontal") < 0 && !facingRight)
        {         // se intoarce stanaga/ dreapta
            Flip();

        }
        if (Input.GetAxisRaw("Horizontal") > 0 && facingRight)        // se intoarce stanaga/ dreapta
        {
            Flip();
        }


    }

    private IEnumerator Dash()
    {
        animator.SetBool("IsJumping", false);
        canDash = false;
        isDashing = true;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = 4f;
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
    private bool IsGrounded2()
    {
        return Physics2D.OverlapCircle(groundCheck2.position, 0.2f, groundLayer);

    }
    public bool UnderCeiling()
    {
        return Physics2D.OverlapCircle(ceelingCheck.position, 0.2f, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("FallDetector"))
        {
            Debug.Log("Collision!!");
            transform.position = respawnPoint.position;

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