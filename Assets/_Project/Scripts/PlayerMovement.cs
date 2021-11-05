using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Debug = UnityEngine.Debug;
using Input = UnityEngine.Input;
using Physics2D = UnityEngine.Physics2D;
using Time = UnityEngine.Time;
using Transform = UnityEngine.Transform;
using Vector2 = UnityEngine.Vector2;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator animatorPlayer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask collisionLayer;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform groundCheckLeft;
    [SerializeField] private Transform groundCheckRight;

    private bool isGrounded;

    private bool canJump = false;
    private float x;

    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded) canJump = true;

        Flip(rb.velocity.x);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position, collisionLayer);
        Move(x);
        if (canJump)
        {
            Jump();
            canJump = false;
        }
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce));
    }

    private void Move(float x)
    {
        if (!animatorPlayer.GetBool("isDead"))
        {
            rb.velocity = new Vector2(x * speed * Time.fixedDeltaTime, rb.velocity.y);
            animatorPlayer.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        }
    }

    private void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}