using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enhancement : MonoBehaviour
{
    public string mechanicName;
    public string mechanicDescription;
    private EnhancementUI display;

    public int price;

    public int incrementPrice;

    protected int enhancementLevel = 0;

    private bool acquired = false;

    public abstract void Empower();

    public void CheckEnhancement()
    {
        enhancementLevel = PlayerPrefs.GetInt(this.GetType().Name);
        //nameText.text = mechanicName;
        //descriptionText.text = mechanicDescription;
        //levelText.text = enhancementLevel.ToString();

        if (enhancementLevel == 0)
        {
            acquired = false;
        }
    }
    public string[] ObtainInformation()
    {
        return new string[]{mechanicName, mechanicDescription, enhancementLevel.ToString(), priceToPay().ToString()};
    }
    public void SetDisplay(EnhancementUI ui)
    {
        display = ui;
    }

    public void PurchaseEnhancement()
    {
        int price = priceToPay();
        if (ResourceManager.instance.ReturnCoinAsset() >= price )
        {
            if (!acquired)
            {
                acquired = true;
            }
            Debug.Log("Paid: " + this.GetType().Name);
            ResourceManager.instance.DeductCoinAsset(price);
            enhancementLevel++;
            SaveEnhancement();

            display.UpdateInfo(enhancementLevel.ToString(), priceToPay().ToString());
        }      
        else
        {
            Debug.Log("NOT ENOUGH");
        }
    }
    public void SaveEnhancement()
    {
        PlayerPrefs.SetInt(this.GetType().Name, enhancementLevel);
    }
    private int priceToPay()
    {
        if (!acquired)
        {           
            return price;
        }
        else
        {
            return (incrementPrice * enhancementLevel);
        }
    }
}
