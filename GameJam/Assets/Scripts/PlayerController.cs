using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 movementVector;
    private Vector2 movement;
    private Rigidbody2D rb2d;
    public float currentSpeed;
    public float Acceleration;
    public float MaxSpeed;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
        CalculateSpeed();
        movementVector *= currentSpeed;
        movement = movementVector;
    }
    private void CalculateSpeed()
    {

        if (MathF.Abs(movementVector.y) == 0 && MathF.Abs(movementVector.x) == 0)
        {
            currentSpeed += -Acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed += Acceleration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, MaxSpeed);
    }

    //private void CheckSide()
    //{
    //    if (movementVector.x < 0)
    //    {
    //        //gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
    //        gameObject.GetComponent<SpriteRenderer>().flipX = true;
    //    }
    //    else
    //    {
    //        //gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    //        gameObject.GetComponent<SpriteRenderer>().flipX = false;
    //    }
    //}
    private void FixedUpdate()
    {
        rb2d.velocity = movement * Time.deltaTime;
    }
}
