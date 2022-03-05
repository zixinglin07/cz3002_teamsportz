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
        }
        /*System.Type[] types = System.Reflection.Assembly.GetExecutingAssembly().GetTypes();
        System.Type[] possible = (from System.Type type in types where type.IsSubclassOf(typeof(Enhancement)) select type).ToArray();
        
        foreach(System.Type type in possible)
        {
            Debug.Log("Name: " + type.Name);
        }*/

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

}
