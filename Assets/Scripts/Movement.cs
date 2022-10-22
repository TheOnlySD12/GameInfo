using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] private float runSpeed = 15.0f;
    private Rigidbody2D body;
    [SerializeField] private float jumpspeed = 8.0f;

    private bool isjumping;

    bool facingRight;



    private double falltimer = 0.5;

    public Animator animator;


    




    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }



    private void Update()
    {

        body.velocity = new Vector2(Input.GetAxis("Horizontal") * runSpeed, body.velocity.y); //mers orizontal

        //animator.SetFloat("Speed",);
        if (Input.GetButton("Jump") && (!isjumping || falltimer>0))  //sarit
        {
            
            body.velocity = new Vector2(body.velocity.x, jumpspeed);    //sarit
            isjumping = true;
            falltimer -= Time.deltaTime;
            animator.SetBool("IsJumping",true);
        }
        if (Input.GetButtonUp("Jump"))
        {
            falltimer = 0;
            animator.SetBool("IsJumping",false);
           
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

    



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {     //check daca e pe pamant
            isjumping = false;
            falltimer = 0.25;
        }
    }

    void Flip()
    {

        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;    //flip stanga dreapta
    }


}
