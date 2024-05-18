using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnTrigger : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] EnemySpawnerPosition;
    private int _randomSpawnPoints;
    public float RepearRate = 3f;
    public int DestroySpawner = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            InvokeRepeating("EnemySpawner", 0.5f, RepearRate);
            Destroy(gameObject, DestroySpawner);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void EnemySpawner()
    {
        _randomSpawnPoints = Random.Range(0, EnemySpawnerPosition.Length);
        Instantiate(enemyPrefab, EnemySpawnerPosition[_randomSpawnPoints].position, Quaternion.identity);
    }
}