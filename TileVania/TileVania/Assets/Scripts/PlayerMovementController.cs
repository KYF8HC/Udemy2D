using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpVelocity = 10f;
    [SerializeField] float climbSpeed = 10f;
    Vector2 moveInput;
    Rigidbody2D rigidbody2D;
    Animator playerAnimator;
    CapsuleCollider2D playerCapsuleCollider2D;
    float gravityScale;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        gravityScale = rigidbody2D.gravityScale;
    }
    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnJump(InputValue value)
    {
        if(!playerCapsuleCollider2D.IsTouchingLayers
            (LayerMask.GetMask("Ground"))){return;}
        if(value.isPressed)
        {
            rigidbody2D.velocity += new Vector2(0f, jumpVelocity);
        }
    }
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon;
        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidbody2D.velocity.x), 1f);
        }
    }
    void ClimbLadder()
    {
        if(!playerCapsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Climb")))
        {
            rigidbody2D.gravityScale = gravityScale;
            playerAnimator.SetBool("Climb", false);
            return;
        }
            Vector2 climbVelocity = new Vector2(rigidbody2D.velocity.x, moveInput.y * climbSpeed);
            rigidbody2D.velocity = climbVelocity;
            rigidbody2D.gravityScale = 0f;

            bool playerHasVerticalSpeed = Mathf.Abs(rigidbody2D.velocity.y) > Mathf.Epsilon;
            playerAnimator.SetBool("Climb", playerHasVerticalSpeed);
        
    }
}