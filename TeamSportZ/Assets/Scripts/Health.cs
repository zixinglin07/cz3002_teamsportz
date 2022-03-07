using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    /*void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }*/
    public void DeductHealth()
    {
        health--;
        hearts[health].sprite = emptyHeart;
        if (health == 0)
        {
            this.GetComponent<PlayerController>().ResetCharacter();
        }
    }
    public void ResetHealth()
    {
        health = numOfHearts;
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }


}
