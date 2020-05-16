﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 3.0f;
    
    public Joystick joystick;

    private Vector2 direction;

    public static bool canWalk = false;
    public static bool empty = false;
 
    void Update()
    {
        if(AlienMovement.alienControl == false && Manager.inGame == true)
        {
            direction = joystick.Direction * speed * Time.deltaTime;
            transform.position += new Vector3(direction.x, direction.y, 0f);
        }

        KeyboardMovement();
        LimitateAxis();
    }

    void KeyboardMovement()
    {
        if(AlienMovement.alienControl == false && Manager.inGame == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.up * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.up * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }
        }
    }

    private void LimitateAxis()
    {
        if (gameObject.transform.position.y >= 7.5f)
        {
            transform.position = new Vector3(transform.position.x, 7.5f, 0);
        }

        else if (gameObject.transform.position.y <= 2.1f)
        {
            transform.position = new Vector3(transform.position.x, 2.1f, 0);
        }

        else if (gameObject.transform.position.x <= -20f)
        {
            transform.position = new Vector3(-20f, transform.position.y, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground")
        {
            canWalk = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Ground")
        {
            canWalk = false;
        }
    }
}
