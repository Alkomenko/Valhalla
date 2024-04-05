using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = System.Random;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    public int damage;
    private Animator animator;
    private BoxCollider2D boxCollider2D;
    private GameObject player;
    public TMP_Text textDamage;

    private Statistics statistics;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        statistics = FindObjectOfType<Statistics>();
    }

    private bool isDead;
    private void Update()
    {
        if (!isDead)
        {
            if (health <= 0) StartCoroutine(Dead());
            LocalScaleRotate();
            Move();
        }
        
    }

    void Move()
    {
        transform.position =
            Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
    }
    IEnumerator Dead()
    {
        isDead = true;
        statistics.score++;
        boxCollider2D.enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        int randomIdAnimation = UnityEngine.Random.Range(0, 2);
        animator.SetInteger(Animator.StringToHash("Dead"), randomIdAnimation);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    public void TakeDamage(int damageVal)
    {
        /*StartCoroutine(CreateTextDamage(damageVal));*/
        health -= damageVal;
    }

  //  public void OnTriggerEnter2D(Collider2D other)
  //  {
  //      if (other.CompareTag("Player"))
  //     {
  //          other.GetComponent<Player>().TakeDamage(damage);
  //      }
  //  }

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