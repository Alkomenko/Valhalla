using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss : MonoBehaviour
{
    
    public float speed;
    public int damage;
    public GameObject bloodPrefab;
    public float startTimeBtwAttack;
    private float timeBtwAttack;
    private float stopTime;
    public float normalSpeed;
    
    
    public Animator animator;
    private GameObject player1;
    private Player player;
    private Vector2 direction;
    private Rigidbody2D rb;
    
    void Start()
    {
        player1 = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        normalSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if (player1 != null)
        {
            if (stopTime <= 0)
            {
                speed = normalSpeed;
            }
            else
            {
                speed = 0;
                stopTime -= Time.deltaTime;
            }

            direction = player1.transform.position - transform.position;
            direction.Normalize();
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.SetFloat("Speed", direction.sqrMagnitude);
            rb.velocity = new Vector2(speed * direction.x, speed * direction.y);
        }
    }
    /*public void OnAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Player>().TakeDamage(damage);
        }
    }*/
    public void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            if (timeBtwAttack <= 0)
            {
                //animator.SetTrigger("attack");
                OnEnemyAttack();
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }
    public void OnEnemyAttack()
    {
        Instantiate(bloodPrefab, player.transform.position, Quaternion.identity);
        player.health -= damage;
        timeBtwAttack = startTimeBtwAttack;
    }
}