using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyFreeGame : MonoBehaviour
{
    
    public int maxHealth = 100;
    private int health;
    public float speed;
    public int damage;
    public GameObject bloodPrefab;
    public float startTimeBtwAttack;
    private float timeBtwAttack;
    private float stopTime;
    public float startStopTime;
    public float normalSpeed;
    
    
    public Animator animator;
    private BoxCollider2D boxCollider2D;
    private GameObject player1;
    private Player player;
    public TMP_Text textDamage;
    private Statistics statistics;

    public GameObject Gem;
    
    void Start()
    {
        player1 = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        statistics = FindObjectOfType<Statistics>();
        player = FindObjectOfType<Player>();
        health = maxHealth;
        normalSpeed = speed;
    }
    
    private void Update()
    {
        if (player != null)
        {
            Move();
            Rotate();
        }

        if (stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
    }
    void Move()
    {
        Vector2 sum = transform.position + transform.forward;
        transform.position =
            Vector2.MoveTowards(sum, player1.transform.position, Time.deltaTime * speed);
    }

    public void TakeDamage(int damage)
    {
        stopTime = startStopTime;
        StartCoroutine(CreateTextDamage(damage));
        animator.SetTrigger("Hurt");
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        this.enabled = false;
        statistics.score++;
        Invoke("DelayedDie", 1f); // Вызов метода DelayedDie через * секунды
    }

    void DelayedDie()
    {
        DropGem();
        Destroy(gameObject);
    }

    void Rotate()
    {
        if (player1.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    
    IEnumerator CreateTextDamage(int damageVal)
    {
        TMP_Text text = Instantiate(textDamage,
            new Vector2(transform.position.x + UnityEngine.Random.Range(-1, 1), transform.position.y + UnityEngine.Random.Range(-1, 1)),
            Quaternion.identity);
        text.text = damageVal + "";
        yield return new WaitForSeconds(0.7f);
        Destroy(text.gameObject);
    }
    
    public void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            if (timeBtwAttack <= 0)
            {
                animator.SetTrigger("attack");
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
    
    void DropGem()
    {
        Vector2 position = transform.position;
        GameObject gem = Instantiate(Gem, position + new Vector2(0.0f, 1.0f), Quaternion.identity);
        gem.SetActive(true);
        Destroy(gem,10f);
    }
}