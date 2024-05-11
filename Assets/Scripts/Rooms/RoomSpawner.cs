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
            if (direction == Direction.Left)
            {
                rand = Random.Range(0, variants.leftRooms.Length);
                Instantiate(variants.leftRooms[rand], transform.position, variants.leftRooms[rand].transform.rotation);
                currentRooms++;
            }
            else if (direction == Direction.Up)
            {
                rand = Random.Range(0, variants.upRooms.Length);
                Instantiate(variants.upRooms[rand], transform.position, variants.upRooms[rand].transform.rotation);
            }
            else if (direction == Direction.Down)
            {
                rand = Random.Range(0, variants.downRooms.Length);
                Instantiate(variants.downRooms[rand], transform.position, variants.downRooms[rand].transform.rotation);
            }
            else if (direction == Direction.Right)
            {
                rand = Random.Range(0, variants.rightRooms.Length);
                Instantiate(variants.rightRooms[rand], transform.position, variants.rightRooms[rand].transform.rotation);
            }
        }
        spawned = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("RoomPoint") && other.GetComponent<RoomSpawner>().spawned)
        {
            Destroy(gameObject);
        }
    }
}