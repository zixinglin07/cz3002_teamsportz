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
            StartCoroutine(DeathAnimation());
        }
        else
        {
            ResourceManager.instance.ActivateEnhancement("Immortality");
            this.GetComponent<Animator>().Play("Player_Hit");
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
    IEnumerator DeathAnimation()
    {
        if (this.GetComponent<Rigidbody2D>() != null)
        {
            Debug.Log("FREEZING");
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            yield return new WaitForSeconds(1.0f);
            Debug.Log("ADD FORCE");
            rb.AddForce(this.transform.up * 500f);
            rb.freezeRotation = false;
            this.GetComponent<Collider2D>().enabled = false;
        }

        yield return new WaitForSeconds(1.0f);
        Debug.Log("RESET");
        this.GetComponent<PlayerController>().ResetCharacter();
    }


}
