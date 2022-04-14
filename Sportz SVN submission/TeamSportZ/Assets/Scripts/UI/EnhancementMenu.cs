using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnhancementMenu : MonoBehaviour
{
    public Transform content;
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Enhancement enhance in ResourceManager.instance.enhancements)
        {
            GameObject craftedUI = Instantiate(UI, content);
            enhance.SetDisplay(craftedUI.GetComponent<EnhancementUI>().Initialise(enhance));
        }
    }
}
