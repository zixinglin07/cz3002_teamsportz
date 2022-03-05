using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnhancementUI : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI description;
    public TextMeshProUGUI level;
    public TextMeshProUGUI price;
    public Button purchase;

    public EnhancementUI Initialise(Enhancement enhancement)
    {
        string[] info = enhancement.ObtainInformation();
        name.text = info[0];
        description.text = info[1];
        level.text = info[2];
        price.text = info[3];

        purchase.onClick.AddListener(() => enhancement.PurchaseEnhancement());

        return this;
    }
    public void UpdateInfo(string level, string price)
    {
        this.level.text = level;
        this.price.text = price;
    }
}
