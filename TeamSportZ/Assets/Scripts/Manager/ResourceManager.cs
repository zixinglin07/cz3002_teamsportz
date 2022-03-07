using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance = null;
    public List<Enhancement> enhancements = new List<Enhancement>();
    public string coinKey = "Coin";
    int coin = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        
    }
    void Start()
    {
        coin = PlayerPrefs.GetInt(coinKey);
        foreach (Enhancement enhance in enhancements)
        {
            enhance.CheckEnhancement();
            enhance.Empower();
        }
        /*System.Type[] types = System.Reflection.Assembly.GetExecutingAssembly().GetTypes();
        System.Type[] possible = (from System.Type type in types where type.IsSubclassOf(typeof(Enhancement)) select type).ToArray();
        
        foreach(System.Type type in possible)
        {
            Debug.Log("Name: " + type.Name);
        }*/

    }
    void EnableEnhancement()
    {
        foreach (Enhancement enhance in enhancements)
        {
            if (enhance.GetAcquire())
                enhance.Empower();
        }
    }
    public int ReturnCoinAsset()
    {
        return coin;
    }
    public void DeductCoinAsset(int payment)
    {
        coin -= payment;
        PlayerPrefs.SetInt(coinKey, coin);
    }
    public void AddCoin(int newCoins)
    {
        //Debug.Log("Coin Added");
        coin += newCoins;
        PlayerPrefs.SetInt(coinKey, coin);
    }
    public void ActivateEnhancement(string enhancement)
    {
        foreach(Enhancement enhance in enhancements)
        {
            if (enhance.mechanicName == enhancement)
            {
                if (enhance.GetAcquire())
                    enhance.Empower();

                return;
            }
        }
    }

}
