using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public string goMain;
    public static SettingsMenu instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

    }

    public void GoToMain()
    {
        Application.LoadLevel(goMain);
    }
}
