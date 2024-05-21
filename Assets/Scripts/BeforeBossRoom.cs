using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeBossRoom : MonoBehaviour
{
    [Header("Walls")]
    public GameObject[] walls;
    public GameObject wallEffect;
    
    [Header("Enemies")]
    public GameObject BossRoom;
    public Transform[] enemySpawners;

    [HideInInspector] public List<GameObject> enemies;
    private RoomVariants variants;
    private bool spawned;
    private bool wallsDestroyed;

    private void Start()
    {
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !spawned)
        {
            spawned = true;

            foreach (Transform spawner in enemySpawners)
            {
                GameObject enemy = Instantiate(BossRoom, spawner.position, Quaternion.identity) as GameObject;
                enemy.transform.parent = transform;
                enemies.Add(enemy);
            }
            
            // Уничтожаем стены сразу, как только игрок заходит в триггер
            DestroyWalls();
        }   
    }

    public void DestroyWalls()
    {
        foreach (GameObject wall in walls)
        {
            if (wall != null && wall.transform.childCount != 0)
            {
                Instantiate(wallEffect, wall.transform.position, Quaternion.identity);
                Destroy(wall);
            }
        }

        wallsDestroyed = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (wallsDestroyed && other.CompareTag("Wall"))
        {
            Destroy(other.gameObject);
        }
    }
}