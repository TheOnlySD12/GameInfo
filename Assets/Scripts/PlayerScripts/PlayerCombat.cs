using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Animations;


public class PlayerCombat : MonoBehaviour
{
    /*private void Start() {
        if (File.Exists(Application.persistentDataPath + "/player.ugabuga")) {
            GameData data = SaveSystem.LoadPlayer();
            currentHealth = data.player_health;
            healthBar.SetHealth(data.player_health);
            Vector2 position;
            position.x = data.position[0];
            position.y = data.position[1];
            transform.position = position;
            Debug.Log("Loaded Save");
        }
    }*/

    [SerializeField] public Rigidbody2D rb;
    private float bouncePower = 8f;

    public int checkpoint;

    

    

    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public Transform downAirAttackPoint;
    public float downAirAttackRange = 0.5f;
    private bool lookingDown;

    public Transform upAirAttackPoint;
    public float upAirAttackRange = 0.5f;
    private bool lookingUp;

    public float coolDown = 1;

    public float hCoolDown = 1;
    public float dCoolDown = 0.33f;
    private float attackCooldown;
    private float hSpecialTimer;

    public float dTimeLimiter = 0.33f;

    public int attackDamage = 5;

    public int heavyAttackDamage = 15;


    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public Transform ceelingCheck;

    public int maxHealth = 200;
    // Trebuie sa fie public ca sa il accesez din GameData
    public int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    
    // Update is called once per frame
    void Update()
    {

        /*if (Input.GetKeyDown(KeyCode.UpArrow))//detecteaza daca se uita in sus
        {
            lookingUp = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            lookingUp = false;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))//detecteaza daca se uita in jos // efectiv Input.GetAxis("Vertical") < 0
        {
            lookingDown = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            lookingDown = false;
        }*/
        if (!IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.X) && attackCooldown <= 0 && !lookingDown && !lookingUp)
            {
                AirAttack();
            }
            if (lookingDown && Input.GetKeyDown(KeyCode.X))
            {
                DownAirAttack();
            }
            if (lookingUp && Input.GetKeyDown(KeyCode.X))
            {
                UpAirAttack();
            }
        }
        // Set coolDown timers

        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }
        if (dTimeLimiter > 0)
        {
            dTimeLimiter -= Time.deltaTime;
        }
        if (hSpecialTimer > 0)
        {
            hSpecialTimer -= Time.deltaTime;
        }

        // Determine if it can attack and the type of the attack
        if (IsGrounded() && !UnderCeeling())                     // can attack only if it's not jumping
        {
            if(Input.GetKeyDown(KeyCode.X) && Input.GetAxisRaw("Vertical") < 0)
            {
                UpAirAttack();
            }

            if (!lookingUp)
            {
                if (Input.GetKeyDown(KeyCode.X) && attackCooldown <= 0 )
                {


                    if (dTimeLimiter > 0)
                    {
                        DoubleAttack();
                        dTimeLimiter = 0;
                        attackCooldown = dCoolDown;

                    }
                    else
                    {
                        Attack();
                        dTimeLimiter = 0.33f;
                    }
                }

                if (Input.GetKeyDown(KeyCode.F) && hSpecialTimer <= 0 )
                {

                    HeavyAttack();
                    hSpecialTimer = hCoolDown;


                }
            }
        }

    }

    void Attack()//atac normal
    {
        if (Time.timeScale > 0)
        {
            animator.SetTrigger("Attack");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (!enemy.isTrigger)
                {
                    enemy.GetComponent<GenericEnemy>().TakeDamage(attackDamage);
                }
            }
        }   
    }
    void AirAttack()//atac in aer
    {
        if (Time.timeScale > 0)
        {
            animator.SetTrigger("AirAttack");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (!enemy.isTrigger)
                {
                    enemy.GetComponent<GenericEnemy>().TakeDamage(attackDamage);
                }


            }
        }
    }
    void DownAirAttack()//atac in aer in jos
    {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(downAirAttackPoint.position, downAirAttackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (!enemy.isTrigger)
            {
                enemy.GetComponent<GenericEnemy>().TakeDamage(attackDamage);
                rb.velocity = new Vector2(rb.velocity.x, bouncePower);
            }

        }
    }

    void UpAirAttack()//atac in aer in sus
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(upAirAttackPoint.position, upAirAttackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {

            if (!enemy.isTrigger)
            {
                enemy.GetComponent<GenericEnemy>().TakeUpDamage(attackDamage);
            }
        }
    }

    void HeavyAttack()//atac mai puternic
    {
        if (Time.timeScale > 0)
        {
            animator.SetTrigger("HeavyAttack");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {

                if (!enemy.isTrigger)
                {
                    enemy.GetComponent<GenericEnemy>().TakeDamage(heavyAttackDamage);
                }

            }
        }

    }

    void DoubleAttack()//atac dublu
    {

        if (Time.timeScale > 0)
        {
            animator.SetTrigger("DoubleAttack");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {

                if (!enemy.isTrigger)
                {
                    enemy.GetComponent<GenericEnemy>().TakeDamage(attackDamage +5);
                }



            }
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void OnDrawGizmosSelected()//pentru a vizualiza distanta atacului din unity editor
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(downAirAttackPoint.position, downAirAttackRange);
        Gizmos.DrawWireSphere(upAirAttackPoint.position, upAirAttackRange);
    }

    public bool UnderCeeling()
    {
        return Physics2D.OverlapCircle(ceelingCheck.position, 0.2f, groundLayer);
    }

    public void TakeBulletDamage(int enemydamage)
    {

        currentHealth -= enemydamage;
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("Hit");
        if (currentHealth <= 0)
        {
            PlayerDie();
        }
    }


    void PlayerDie()
    {
        Debug.Log("Player died");
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death"); //asa sa se numeasca animatia
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
