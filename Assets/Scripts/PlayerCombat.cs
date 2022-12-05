using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class PlayerCombat : MonoBehaviour
{
    private void Start() {
        if (File.Exists(Application.persistentDataPath + "/player.ugabuga")) {
            PlayerData data = SaveSystem.LoadPlayer();
            Vector2 position;
            position.x = data.position[0];
            position.y = data.position[1];
            transform.position = position;
        }
    }

    public Animator animator;
 
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float coolDown = 1;
    
    public float hCoolDown = 1;
    public float dCoolDown = 0.33f; 
    private float attackCooldown;

    public float dTimeLimiter = 0.33f;

    public int attackDamage = 5;

    public int heavyAttackDamage = 15;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public Transform ceelingCheck;

    public void SavePlayer(){
        SaveSystem.SavePlayer(this);
    }

    // Update is called once per frame
    void Update()
    {
       
        // Set coolDown timers
        
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }
        if (dTimeLimiter >0)
        {
            dTimeLimiter -= Time.deltaTime;
        }


        // Determine if it can attack and the type of the attack
        if (IsGrounded() && !UnderCeeling())                     // can attack only if it's not jumping
        {


            if (Input.GetKeyDown(KeyCode.X) && attackCooldown <= 0) 
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

            if (Input.GetKeyDown(KeyCode.F) && attackCooldown <= 0 )
            {
            
                HeavyAttack();
                attackCooldown = hCoolDown;


            }
        }
    }

    void Attack()
    {

        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {

            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            
        }

    }

    void HeavyAttack()
    {

        animator.SetTrigger("HeavyAttack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {

            enemy.GetComponent<Enemy>().TakeDamage(heavyAttackDamage);
            
        }
        
    
    }

    void DoubleAttack()
    {

        animator.SetTrigger("DoubleAttack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {

            enemy.GetComponent<Enemy>().TakeDamage(attackDamage+5);
            
            

        }

    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }
    public bool UnderCeeling()
    {
        return Physics2D.OverlapCircle(ceelingCheck.position, 0.2f, groundLayer);
    }
}
