using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public ControlType controlType;
    public float health;
    public int numOfHearts;
    //public float heal;
    
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public enum ControlType{Android, PC}
    
    public GameObject DeadPanel;
    void Start()
    {
        
    }
    
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        // health += Time.deltaTime * heal; // Регенерация здоровья
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

            if (health < 1)
            {
                DeadPanel.SetActive(true);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (health < 5 && other.CompareTag("Potion"))
        {
            health++;
            Destroy(other.gameObject);
        }
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    
}