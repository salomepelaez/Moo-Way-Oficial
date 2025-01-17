﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource menu;
    public AudioSource restartButton;
    public AudioSource startLevel;
    public AudioSource button;

    public GameObject about;
    public GameObject credits;

    public void Instructions()
    {
        startLevel.Play();
        SceneManager.LoadScene("Instructions");
    }
    
    public void StartGame()
    {
        startLevel.Play();
        SceneManager.LoadScene("FirstLevel");
    }

    public void Restart()
    {       
        SceneManager.LoadScene("FirstLevel");
    }
      
    public void AboutButton()
    {
        button.Play();
        about.SetActive(true);
        credits.SetActive(false);
    }

    public void CreditsButton()
    {
        button.Play();
        credits.SetActive(true);
        about.SetActive(false);
    }

    public void Leave()
    {
        button.Play();
        about.SetActive(false);
    }

    public void BackToMenu()
    {
        menu.Play();
        SceneManager.LoadScene("Menu");
    }
}
