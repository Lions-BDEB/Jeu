using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float runSpeed = 3f;
    [SerializeField] private float jumpSpeed = 10f;
    private Animator myAnimator;
    private Collider2D myCollider2D;
    private bool isAlive = true;
    private float climbSpeed = 1f;
    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        myCollider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        Run();
        FlipSprite();
        Jump();
        // GetComponent<Rigidbody2D>().rotation = 0f;
    }

    private void Run()
    {
        float controlThrow  =  Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed ,GetComponent<Rigidbody2D>().velocity.y);
        GetComponent<Rigidbody2D>().velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);

    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            GetComponent<Rigidbody2D>().velocity += jumpVelocity;
        }
    }
    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > Mathf.Epsilon; // if greater than 0
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x),1f);
        }
    }

}
