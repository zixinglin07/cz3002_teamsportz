using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    public string goMain;

    public void GoToMain()
    {
        Application.LoadLevel(goMain);
    }
}
