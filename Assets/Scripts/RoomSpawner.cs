using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomSpawner : MonoBehaviour
{
    public Direction direction;
    public int maxRooms = 7;
    public int currentRooms = 0;

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        None
    }

    private RoomVariants variants;
    private int rand;
    private bool spawned = false;
    private float waitTime = 3f;

    private void Start()
    {
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
        Destroy(gameObject, waitTime);
        Invoke("Spawn", 0.1f);
    }

    public void Spawn()
    {
        if (!spawned)
        {
            if (currentRooms < maxRooms)
            {
                if (direction == Direction.Left)
                {
                    rand = Random.Range(0, variants.leftRooms.Length);
                    Instantiate(variants.leftRooms[rand], transform.position, variants.leftRooms[rand].transform.rotation);
                }
                currentRooms++;
            }
            else
            {
                rand = Random.Range(0, variants.bossRoom.Length);
                Instantiate(variants.bossRoom[rand], transform.position, variants.bossRoom[rand].transform.rotation);
            }
            spawned = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("RoomPoint") && other.GetComponent<RoomSpawner>().spawned)
        {
            Destroy(gameObject);
        }
    }
}