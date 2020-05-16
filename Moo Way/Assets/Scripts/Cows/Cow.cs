﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    private Transform target;
    private float distance;
   
    public static bool floating = false;

    private int counter = 0;

    private void Start()
    {
        target = FindObjectOfType<Player>().GetComponent<Transform>();
    }

    private void Update()
    {
        if(counter > 1)
        {
            Debug.Log("ganates");
        }
    }

    public void PickUpCow()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if(distance <= 3 && PlatformActivator.built == true)
        {
            floating = true;
        }
    }

    public void DropCow()
    {
        floating = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Platform")
        {
            Destroy(this.gameObject);
            counter = counter + 1;
            Debug.Log(counter);
        }
    }
}
