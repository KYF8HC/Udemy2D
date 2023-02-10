using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    Vector2 moveInput;
    Rigidbody2D rigidbody2D;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Run();
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void Run()
    {
        Vector2 playerVelocity = 
        new Vector2(moveInput.x * moveSpeed, rigidbody2D.velocity.y);
                    rigidbody2D.velocity = playerVelocity;
        if (moveInput.x != 0)
            transform.localScale = new Vector3(transform.localScale.x * moveInput.x,  
                                transform.localScale.y,  transform.localScale.z);
    }

}
