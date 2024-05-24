using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage = 25;
    public LayerMask whatIsSolid;
    public GameObject destroyEffect;

    private void Start()
    {
        Invoke("DestroyBullet", lifetime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            else if (hitInfo.collider.CompareTag("Boss"))
            {
                hitInfo.collider.GetComponent<BossHealth>().TakeDamage(damage);
            }
            DestroyBullet();
            Destroy(gameObject);
        }

        transform.Translate(Vector2.up * (speed * Time.deltaTime));
    }

    public void DestroyBullet()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
