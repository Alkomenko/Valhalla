using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Joystick joystick;
    public float Speed;
    public Animator animator;
    private Rigidbody2D rb;
    private Vector2 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        direction = new Vector2(joystick.Horizontal, joystick.Vertical);

        animator.SetFloat("Horizontal",direction.x);
        animator.SetFloat("Vertical",direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
        rb.velocity = new Vector2(Speed * direction.x, Speed * direction.y);
    }
}
