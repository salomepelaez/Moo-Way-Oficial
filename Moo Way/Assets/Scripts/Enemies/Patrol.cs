﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    private float startWaitTime = 3f;

    public Transform[] moveSpots;
    private int randomSpot;

    Manager manager;

    void Awake()
    {
    }

    void Start()
    {
        manager = Manager.Instance;

        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if(manager.inGame == true)
        {
            if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
            {
                if(waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Length);
                    waitTime = startWaitTime;
                }

                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }
}
