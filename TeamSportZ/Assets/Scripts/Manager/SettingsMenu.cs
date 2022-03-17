using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public string goMain;
    public void GoToMain()
    {
        Application.LoadLevel(goMain);
    }
}
