﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private float speed = 3.5f;
    
    public Joystick joystick;

    private Vector2 direction;

    private bool empty;

    public GameObject particle;

    public TextMeshProUGUI fuelText;

    Manager manager;
    
    void Awake()
    {
        manager = Manager.Instance;
    }

    void Start()
    {
        InvokeRepeating("LoseFuel", 5f, 1f);
        manager.fuel = 45;

        manager.canWalk = false;
        manager.getOut = false;
        empty = false;

        particle.SetActive(false);
    }

    void Update()
    {
        if(AlienMovement.alienControl == false && manager.inGame == true)
        {
            direction = joystick.Direction * speed * Time.deltaTime;
            transform.position += new Vector3(direction.x, direction.y, 0f);
        }

        LimitateAxis();
        ActivateParticles();
        CheckIfWin();
    }

    private void LimitateAxis()
    {
        if (gameObject.transform.position.y >= 16f)
        {
            transform.position = new Vector3(transform.position.x, 16f, 0);
        }

        else if (gameObject.transform.position.y <= 2.1f)
        {
            transform.position = new Vector3(transform.position.x, 2.1f, 0);
        }

        else if (gameObject.transform.position.x <= -20f)
        {
            transform.position = new Vector3(-20f, transform.position.y, 0);
        }

        else if (gameObject.transform.position.x >= 156f)
        {
            transform.position = new Vector3(156f, transform.position.y, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground")
        {
            manager.canWalk = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Ground")
        {
            manager.canWalk = false;
        }
    }

    void LoseFuel()
    {
        if(manager.inGame == true && empty == false && AlienMovement.alienControl == false)
        {
            manager.fuel = manager.fuel - 1;   
            if(manager.fuel <= 0)
            {
                empty = true; 
                manager.getOut = true;  
                StartCoroutine("FuelText");    
                InvokeRepeating("GetFuel", 5f, 1f);    
            }    
        }
    }

    void GetFuel()
    {
        if(empty == true)
        {
            manager.fuel = manager.fuel + 1;

            if(manager.fuel >= 45)
            {
                empty = false;
            }
        }
    }
   
    IEnumerator FuelText()
    {
        fuelText.text = "You ran out of energy, let the ship load";

        yield return new WaitForSeconds(4);

        fuelText.text = "";
    }

    void ActivateParticles()
    {
        if(manager.floating == true)
        {
            particle.SetActive(true);
        }

        else
            particle.SetActive(false);
    }

    void CheckIfWin()
    {
        if(manager.cowCounter == 3 && gameObject.transform.position.x >= 156f)
        {
            Debug.Log("ganó de a mentis");
            manager.inGame = false;
            manager.bigWinner = true;
        }
    }
}
