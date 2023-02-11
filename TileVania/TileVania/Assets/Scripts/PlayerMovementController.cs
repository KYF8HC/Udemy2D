using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpVelocity = 10f;
    [SerializeField] float climbSpeed = 10f;
    [SerializeField] Vector2 deathKick = new Vector2(10f, 10f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    Vector2 moveInput;
    Rigidbody2D playerRigidbody2D;
    Animator playerAnimator;
    CapsuleCollider2D playerBodyCapsuleCollider2D;
    BoxCollider2D playerFeetBoxCollider2D;
    float gravityScale;
    bool isAlive = true;

    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerBodyCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        playerFeetBoxCollider2D = GetComponent<BoxCollider2D>();
        gravityScale = playerRigidbody2D.gravityScale;
    }
    void Update()
    {
        if(!isAlive)return;
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnJump(InputValue value)
    {
        if(!isAlive)return;
        if(!playerFeetBoxCollider2D.IsTouchingLayers
            (LayerMask.GetMask("Ground"))){return;}
        if(value.isPressed)
        {
            playerRigidbody2D.velocity += new Vector2(0f, jumpVelocity);
        }
    }
    void OnFire(InputValue value)
    {
         if(!isAlive)return;
        Instantiate(bullet, gun.position, transform.rotation);
    }
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, playerRigidbody2D.velocity.y);
        playerRigidbody2D.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(playerRigidbody2D.velocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(playerRigidbody2D.velocity.x) > Mathf.Epsilon;
        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRigidbody2D.velocity.x), 1f);
        }
    }
    void ClimbLadder()
    {
        if(!isAlive)return;
        if(!playerFeetBoxCollider2D.IsTouchingLayers(LayerMask.GetMask("Climb")))
        {
            playerRigidbody2D.gravityScale = gravityScale;
            playerAnimator.SetBool("Climb", false);
            return;
        }
            Vector2 climbVelocity = new Vector2(playerRigidbody2D.velocity.x, moveInput.y * climbSpeed);
            playerRigidbody2D.velocity = climbVelocity;
            playerRigidbody2D.gravityScale = 0f;

            bool playerHasVerticalSpeed = Mathf.Abs(playerRigidbody2D.velocity.y) > Mathf.Epsilon;
            playerAnimator.SetBool("Climb", playerHasVerticalSpeed);
    }
    void Die() {
        {
            if(playerBodyCapsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards")))
            {
                isAlive = false;
                playerAnimator.SetTrigger("Dying");
                playerRigidbody2D.velocity = deathKick;
                FindObjectOfType<GameSession>().ProcessPlayerDeath();
            }
        }
    }
}