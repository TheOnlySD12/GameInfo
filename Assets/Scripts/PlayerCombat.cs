using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
 
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float coolDown = 1;
    public float coolDownTimer;

    public float hCoolDown = 1;
    public float hCoolDownTimer;

    public float dCoolDownTimer = 0.33f;

    public int attackDamage = 5;

    public int heavyAttackDamage = 15;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public void SavePlayer(){
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }


    // Update is called once per frame
    void Update()
    {
       
        // Set coolDown timers
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
        if (hCoolDownTimer > 0)
        {
            hCoolDownTimer -= Time.deltaTime;
        }
        if (dCoolDownTimer >0)
        {
            dCoolDownTimer -= Time.deltaTime;
        }


        // Determine if it can attack and the type of the attack
        if (IsGrounded())                     // can attack only if it's not jumping
        {


            if (Input.GetKeyDown(KeyCode.X) && hCoolDownTimer <= 0) 
            {
            

                if (dCoolDownTimer > 0)
                
                {
                DoubleAttack();
                coolDownTimer = 1.5f;
                dCoolDownTimer = 0;

            
                } else {
                Attack();
                coolDownTimer = coolDown;
                dCoolDownTimer = 0.33f;
            
                }
            }

            if (Input.GetKeyDown(KeyCode.F) && hCoolDownTimer <= 0 )
            {
            
                HeavyAttack();
                hCoolDownTimer = hCoolDown;


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

            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            
            

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

}
