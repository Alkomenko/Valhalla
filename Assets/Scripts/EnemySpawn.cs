using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class EnemySpawn : MonoBehaviour
{
    public GameObject plusPrefab;
    public GameObject enemyPrefab;
    public float timeRateSpawn;
    private float timeRate;

    private void Update()
    {
        if (timeRate <= 0)
        {
            StartCoroutine(Spawn());
            timeRate = timeRateSpawn;
        }
        else
        {
            timeRate -= Time.deltaTime;
        }
    }

    IEnumerator Spawn()
    {
        Vector2 topLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 1));
        Vector2 downRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0));
        Vector2 RandomPos = new Vector2 (UnityEngine.Random.Range(topLeft.x, downRight.x), UnityEngine.Random.Range(downRight.y, topLeft.y));
        GameObject plus = Instantiate(plusPrefab, RandomPos, quaternion.identity);
        yield return null;
    }
}
