using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string playGameLevel;
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

    }
}
