using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string playGameLevel;
    public string openCredits;
    private void Start()
    {
        Screen.SetResolution(1920, 1080, false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void PlayGame()
    {
        Application.LoadLevel(playGameLevel);
    }

    public void GoShop()
    {

    }

    public void GoSettings()
    {
       
    }

    public void GoCredits()
    {
        Application.LoadLevel(openCredits);
    }
}
