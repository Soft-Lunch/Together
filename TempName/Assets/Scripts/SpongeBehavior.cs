﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpongeBehavior : MonoBehaviour
{
    public float accel = .8f;
    public float maxSpeed = 10f;

    private Vector2 move;
    private Rigidbody2D rb;

    private bool crouch = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var gamePad = Gamepad.current;
        move = Vector2.zero;

        if (gamePad != null)
        {
            //Controls
            move = gamePad.leftStick.ReadValue();

            if (move.y < 0)
                crouch = true;
            else if (move.y >= 0)
                crouch = false;

            move.y = 0;
        }
        else
        {

            //Some keyboard support
            var keyboard = Keyboard.current;

            if (keyboard.dKey.isPressed)
            {
                move.x += 1;
            }

            if (keyboard.aKey.isPressed)
            {
                move.x -= 1;
            }

            if (keyboard.sKey.isPressed)
                crouch = true;
            else
                crouch = false;
        }

        if (move == Vector2.zero)
            rb.velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        if(move != Vector2.zero)
        {
            rb.AddForce(move * accel * Time.fixedDeltaTime * 100);         
        }

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
