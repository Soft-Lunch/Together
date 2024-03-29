﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PresurePlate : MonoBehaviour
{
    public UnityEvent onPressed;
    public UnityEvent onRelease;

    public Sprite pressed;
    public SpriteRenderer render;

    public Sprite released;

    void Start()
    {
        //render = GetComponent<SpriteRenderer>();
        released = render.sprite;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("DynamicObject"))
        {
            onPressed.Invoke();
            render.sprite = pressed;
            Debug.Log("Player push button");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("DynamicObject"))
        {
            onRelease.Invoke();
            render.sprite = released;
        }
    }
}
