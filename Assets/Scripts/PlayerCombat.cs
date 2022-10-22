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

    public float hCoolDown = 3;
    public float hCoolDownTimer;

    public float dCoolDown = 2;
    public float dCoolDownTimer;

    public int attackDamage = 10;

    public int heavyAttackDamage = 30;

    public int doubleAttackDamage = 20;

    // Update is called once per frame
    void Update()
    {

       // if (Input.GetKeyDown(KeyCode.X))
      //  {

           // Attack();
        
       // }
       
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.X) && coolDownTimer <= 0)
        {
            Attack();
            coolDownTimer = coolDown;
        }

        if(hCoolDownTimer>0)
        {
            hCoolDownTimer -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.F) && hCoolDownTimer <= 0)
        {
            HeavyAttack();
             
            hCoolDownTimer = hCoolDown;
        }

        if (dCoolDownTimer > 0)
        {
            dCoolDownTimer -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.G) && dCoolDownTimer <= 0)
        {
            DoubleAttack();

            dCoolDownTimer = dCoolDown;
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

            enemy.GetComponent<Enemy>().TakeDamage(doubleAttackDamage);

        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }

}
