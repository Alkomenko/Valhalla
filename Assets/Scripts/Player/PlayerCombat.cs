using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public Joystick joystick;

    public float attackRange = 0.5f;
    public int attack;
    public int attackDamage;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;
    private StatsUpgrade _statsUpgrade;

    private void Start()
    {
        _statsUpgrade = new StatsUpgrade();
    }

    void Update()
    {
        
        attackDamage = StatsUpgrade.attackDamage;
        
        if (Time.time >= nextAttackTime)
        {
            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                Attack();
                Debug.Log(attackDamage + "  "  + attack);
                nextAttackTime = Time.time + 1f / attackRate;
            } 
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        if (hitEnemies != null)
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                Enemy enemyComponent = enemy.GetComponent<Enemy>();
            
                if (enemyComponent != null)
                {
                    enemyComponent.TakeDamage(attackDamage);
                }
                
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
