using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mechanic : MonoBehaviour
{
    public string mechanicName;
    public float duration = 5.0f;
    public static float enhancementTime = 0.0f;

    public abstract void Empower();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.GetComponent<Collider2D>() != null)
        {
            Debug.Log("Name: " + mechanicName + " Activated!");
            Empower();
            ActivatePowerUp();
        }
    }
    private void ActivatePowerUp()
    {
        SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
        Collider2D col = this.GetComponent<Collider2D>();

        if (sprite != null)
        {
            sprite.enabled = false;
        }
        if (col != null)
        {
            col.enabled = false;
        }
    }
    protected void ResetPowerUp()
    {
        SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
        Collider2D col = this.GetComponent<Collider2D>();

        if (sprite != null)
        {
            sprite.enabled = true;
        }
        if (col != null)
        {
            col.enabled = true;
        }
        this.gameObject.SetActive(false);
    }
    protected float TotalTime()
    {
        return duration + enhancementTime;
    }
}
