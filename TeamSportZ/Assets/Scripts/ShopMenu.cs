using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public string goShop;
    // Start is called before the first frame update
    public void goToShop()
    {
        Application.LoadLevel(goShop);
    }
}
