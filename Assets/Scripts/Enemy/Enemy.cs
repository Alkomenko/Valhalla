using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int maxHealth = 100;
    private int currentHealth;
    public float speed;
    public int damage;
    
    public Animator animator;
    private BoxCollider2D boxCollider2D;
    private GameObject player;
    public TMP_Text textDamage;
    private Statistics statistics;
    
    private bool isDead;
    
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        statistics = FindObjectOfType<Statistics>();
    }

    
    void Start()
    {
        currentHealth = maxHealth;
    }
    
    private void Update()
    {
        if (!isDead)
        {
            if (currentHealth <= 0) StartCoroutine(Die());
            LocalScaleRotate();
            Move();
        }
        
    }
    void Move()
    {
        transform.position =
            Vector2.MoveTowards(transform.position + transform.forward, player.transform.position, Time.deltaTime * speed);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        StartCoroutine(CreateTextDamage(damage));
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator Die()
    {
        isDead = true;
        animator.SetBool("Dead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        statistics.score++;
        boxCollider2D.enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    } 
    void LocalScaleRotate()
    {
        if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    
    IEnumerator CreateTextDamage(int damageVal)
    {
        TMP_Text text = Instantiate(textDamage,
            new Vector2(transform.position.x + UnityEngine.Random.Range(-1, 1), transform.position.y + UnityEngine.Random.Range(-1, 1)),
            Quaternion.identity);
        text.text = damageVal + "";
        yield return new WaitForSeconds(0.5f);
        Destroy(text.gameObject);
    }
    
}
