using System;
using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private bool isDead;
    private void Update()
    {
        if (!isDead)
        {
            if (health <= 0) StartCoroutine(Dead());
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
        boxCollider2D.enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        int randomIdAnimation = UnityEngine.Random.Range(0, 1);
        animator.SetInteger(Animator.StringToHash("Dead"), randomIdAnimation);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    public void TakeDamage(int damageVal) => health -= damageVal;
}