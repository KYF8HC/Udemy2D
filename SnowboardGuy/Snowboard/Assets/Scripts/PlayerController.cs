using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    Rigidbody2D rb2D;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;
    void Start()
    {
       rb2D = GetComponent<Rigidbody2D>();
       surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }
    void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }
    void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.UpArrow))
            surfaceEffector2D.speed = boostSpeed;
        else if(!canMove)
            surfaceEffector2D.speed = 0f;
        else
            surfaceEffector2D.speed = baseSpeed;
    }
    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.AddTorque(-torqueAmount);
        }
    }
    public void DisableControlls()
    {
        canMove = false;
    }
}
